using CheckInWpf.ViewModel;
using System;
using System.Windows.Input;

namespace CheckInWpf.Commands
{
    public class LoadOrderNumberCommand : ICommand
    {
        private readonly CheckInCreatorViewModel _checkInCreatorViewModel;

        public event EventHandler? CanExecuteChanged;

        public LoadOrderNumberCommand(CheckInCreatorViewModel checkInCreatorViewModel)
        {
            _checkInCreatorViewModel = checkInCreatorViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           _checkInCreatorViewModel. Initialize();
        }
    }
}
