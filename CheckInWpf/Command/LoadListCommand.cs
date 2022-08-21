using CheckInWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheckInWpf.Commands
{
    public class LoadListCommand : ICommand
    {
        private readonly CheckedInListViewModel _checkedInListViewModel;

        public event EventHandler? CanExecuteChanged;
        public LoadListCommand(CheckedInListViewModel checkedInListViewModel)
        {
            _checkedInListViewModel = checkedInListViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           _checkedInListViewModel.InitializeTheViewModel();
        }
    }
}
