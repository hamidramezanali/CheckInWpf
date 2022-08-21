using CheckInWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.Commands
{
    public class ApplyFilterCommand : CommandBase
    {
        private readonly CheckedInListViewModel _checkedInListViewModel;
        public ApplyFilterCommand(CheckedInListViewModel checkedInListViewModel)
        {
            _checkedInListViewModel = checkedInListViewModel;
        }
        public override void Execute(object parameter)
        {
            _checkedInListViewModel.LoadOrders();
            _checkedInListViewModel.ApplyFilter();
        }
    }
}
