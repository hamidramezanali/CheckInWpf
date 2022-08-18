using CheckInWpf.Commands;
using CheckInWpf.Model;
using CheckInWpf.Service;
using CheckInWpf.Soters;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckInWpf.ViewModel
{
    public class CheckInCreatorViewModel : ViewModelBase

    {

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged(); }
        }

        private string _Comments;

        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; RaisePropertyChanged(); }
        }
        private string _OrderNo;

        public string OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value; RaisePropertyChanged(); }
        }
        private string _Day;

        public string Day
        {
            get { return _Day; }
            set { _Day = value; RaisePropertyChanged(); }
        }
        private string _Month;

        public string Month
        {
            get { return _Month; }
            set { _Month = value; RaisePropertyChanged(); }
        }


        private string _Year;
     

        public string Year
        {
            get { return _Year; }
            set { _Year = value; RaisePropertyChanged(); }
        }


        public MakeOrderCommand AddCommand { get; set; }
        public NavigateCommand CancelCommand { get; set; }
        
        private IOrderNumberService _orderNumberService { get; }


        public CheckInCreatorViewModel(IOrderNumberService orderNumberService,ICheckInService checkInService,NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
       
            AddCommand = new MakeOrderCommand(this,navigationStore, createViewModel,checkInService,orderNumberService);
            CancelCommand = new NavigateCommand(navigationStore,createViewModel);
 
            _orderNumberService = orderNumberService;
            Initialize();
         
        }



        private void Initialize()
        {
            DateTime thisDate = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            Name = String.Empty;
            Comments = String.Empty;
            Day = pc.GetDayOfMonth(thisDate).ToString();
            Month = pc.GetMonth(thisDate).ToString();
            Year = pc.GetYear(thisDate).ToString();
            OrderNo = _orderNumberService.GetOrderNumber().ToString();

        }


        public CheckIn NewOrderMapper()
        {
            return new CheckIn()
            {
                Name = Name,
                OrderNo = Convert.ToInt32(OrderNo),
                Comments = Comments,
                Day = Day,
                Month = Month,
                Year = Year,
                Status = Model.Status.Present
            };
        }
    }
}
