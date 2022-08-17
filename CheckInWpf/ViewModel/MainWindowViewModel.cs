using CheckInWpf.Model;
using CheckInWpf.Service;
using CheckInWpf.Soters;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace CheckInWpf.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigataionStore;
        public ViewModelBase CurrentViewModel => _navigataionStore.CurrentViewModel;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigataionStore = navigationStore;
            _navigataionStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
           RaisePropertyChanged(nameof(CurrentViewModel));
        }
    }
}
