using CheckInWpf.Model;
using CheckInWpf.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace CheckInWpf.ViewModel
{
    internal class CheckInViewModel : ViewModelBase

    {
        private DateTime _FromDate;

        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; RaisePropertyChanged(); }
        }
        private DateTime _ToDate;

        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<CheckIn> _Orders;

        public ObservableCollection<CheckIn> Orders
        {
            get { return _Orders; }
            set { _Orders = value; RaisePropertyChanged(); }
        }

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


        public RelayCommand AddCommand { get; set; }
        private OrderNumberService _orderNumberService { get; }
        private OrderServices _orderServices { get; }



        public CheckInViewModel()
        {
            AddCommand = new RelayCommand(OnAdd);
            _orderNumberService = new OrderNumberService();
            _orderServices = new OrderServices();
            Init();
        }

        private void Init()
        {
            DateTime thisDate = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();

            Name = String.Empty;
            Comments = String.Empty;
            Day = pc.GetDayOfMonth(thisDate).ToString();
            Month = pc.GetMonth(thisDate).ToString();
            Year = pc.GetYear(thisDate).ToString();
            OrderNo = _orderNumberService.GetOrderNumber().ToString();
            Orders = _orderServices.GetAllOrders();


        }

        private void OnAdd()
        {
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Please enter the name");
                return;
            }
            _orderNumberService.SetOrderNumber(Convert.ToInt32(_OrderNo));
            Orders.Add(NewOrderMapper());
            _orderServices.SaveAllOrders(Orders);
            Init();
        }

        private CheckIn NewOrderMapper()
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
