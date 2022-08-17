using CheckInWpf.Commands;
using CheckInWpf.Model;
using CheckInWpf.Soters;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.ViewModel
{
    internal class CheckedInListViewModel :ViewModelBase
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


        private ObservableCollection<CheckInWrapper> _Orders;

        public ObservableCollection<CheckInWrapper> Orders
        {
            get { return _Orders; }
            set { _Orders = value; RaisePropertyChanged(); }
        }
        private ICheckInService _checkInService { get; }

        public NavigateCommand CreateOrderCommand { get; set; }
        public CheckedInListViewModel(ICheckInService checkInService,NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _checkInService = checkInService;
            CreateOrderCommand = new NavigateCommand(navigationStore,createViewModel);
            LoadOrders();


        }

        public void LoadOrders()
        {
            Orders = _checkInService.GetAllOrders();
        }
    }
}
