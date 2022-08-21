using CheckInWpf.Service;
using CheckInWpf.Store;
using CheckInWpf.ViewModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckInWpf.Commands
{
    public class MakeOrderCommand : CommandBase
    {

        private readonly CheckInCreatorViewModel _checkInCreatorViewModel;

        private readonly IOrderNumberService _orderNumberService;

        private readonly ICheckInService _checkInService;

        private readonly NavigationStore _navigationStore;

        private readonly Func<ViewModelBase> _createViewModel;
        public MakeOrderCommand(CheckInCreatorViewModel checkInCreatorViewModel, NavigationStore navigationStore, Func<ViewModelBase> createViewModel, ICheckInService checkInService, IOrderNumberService orderNumberService)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _checkInService = checkInService;
            _orderNumberService = orderNumberService;
            _checkInCreatorViewModel = checkInCreatorViewModel;
        }
        public override void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(_checkInCreatorViewModel.Name))
            {
                MessageBox.Show("Please enter the name");
                return;
            }
            _orderNumberService.SetOrderNumber(Convert.ToInt32(_checkInCreatorViewModel.OrderNo));

            _checkInService.AddOrder(_checkInCreatorViewModel.NewOrderMapper());
            _navigationStore.CurrentViewModel = _createViewModel();
        }

    }
}
