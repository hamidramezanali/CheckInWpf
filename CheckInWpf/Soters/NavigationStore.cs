using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.Soters
{
    public class NavigationStore
    {
        private ViewModelBase _CurrentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { _CurrentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            if(CurrentViewModelChanged != null)
            CurrentViewModelChanged.Invoke();
        }

        public event Action CurrentViewModelChanged;

    }
}
