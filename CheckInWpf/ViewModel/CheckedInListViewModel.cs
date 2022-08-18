using CheckInWpf.Commands;
using CheckInWpf.Model;
using CheckInWpf.Soters;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckInWpf.ViewModel
{
    public class CheckedInListViewModel : ViewModelBase
    {

        private string _FromDay;
        public string FromDay
        {
            get { return _FromDay; }
            set { _FromDay = value; RaisePropertyChanged(); }
        }

        private string _FromMonth;
        public string FromMonth
        {
            get { return _FromMonth; }
            set { _FromMonth = value; RaisePropertyChanged(); }
        }

        private string _FromYear;
        public string FromYear
        {
            get { return _FromYear; }
            set { _FromYear = value; RaisePropertyChanged(); }
        }

        private string _ToDay;
        public string ToDay
        {
            get { return _ToDay; }
            set { _ToDay = value; RaisePropertyChanged(); }
        }

        private string _ToMonth;
        public string ToMonth
        {
            get { return _ToMonth; }
            set { _ToMonth = value; RaisePropertyChanged(); }
        }

        private string _ToYear;
        public string ToYear
        {
            get { return _ToYear; }
            set { _ToYear = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<string> Days => AvailableNumbers(1, 31);
        public ObservableCollection<string> Months => AvailableNumbers(1, 12);
        public ObservableCollection<string> Years => AvailableNumbers(1400, 1420);

        private ObservableCollection<CheckInWrapper> _Orders;

        public ObservableCollection<CheckInWrapper> Orders
        {
            get { return _Orders; }
            set { _Orders = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<CheckInWrapper> _FilteredOrders;

        public ObservableCollection<CheckInWrapper> FilteredOrders
        {
            get { return _FilteredOrders; }
            set { _FilteredOrders = value; RaisePropertyChanged(); }
        }
        private ICheckInService _checkInService { get; }

        public NavigateCommand CreateOrderCommand { get; set; }
        public ApplyFilterCommand ApplyFilterCommand { get; set; }
        public DeleteOrderCommand DeleteOrderCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public CheckedInListViewModel(ICheckInService checkInService, NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _checkInService = checkInService;
            CreateOrderCommand = new NavigateCommand(navigationStore, createViewModel);
            ApplyFilterCommand = new ApplyFilterCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(checkInService,this);
            SaveCommand = new RelayCommand(OnSave);
            InitializeTheViewModel();
        }

        private void OnSave()
        {
            _checkInService.SaveAll(FilteredOrders.ToList());
        }

        public void InitializeTheViewModel()
        {
            InitializeDates();
            LoadOrders();
            ApplyFilter();
        }

        private void InitializeDates()
        {
            DateTime thisDate = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();

            FromDay = ToDay = pc.GetDayOfMonth(thisDate).ToString();
            FromMonth = ToMonth = pc.GetMonth(thisDate).ToString();
            FromYear = ToYear = pc.GetYear(thisDate).ToString();
        }

        public void LoadOrders()
        {
            Orders = _checkInService.GetAllOrders();
        }
        public void ApplyFilter()
        {
            ObservableCollection<CheckInWrapper> gFilteredOrders = new ObservableCollection<CheckInWrapper>();
            foreach (var order in Orders)
            {
                if (order.IsInRange(FromYear,
                   FromMonth,
                   FromDay,
                   ToYear,
                   ToMonth,
                   ToDay))
                    gFilteredOrders.Add(order);
            }
            FilteredOrders = gFilteredOrders;
        }

        public ObservableCollection<string> AvailableNumbers(int start, int end)
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            for (int i = start; i <= end; i++)
            {
                list.Add(i.ToString());
            }
            return list;
        }

    }

 
}
