using CheckInWpf.Soters;
using CheckInWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CheckInWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fa-Ir");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
     
            _navigationStore.CurrentViewModel = new CheckInViewModel();
            MainWindow mainWindow = new MainWindow() { DataContext=new MainWindowViewModel(_navigationStore)};
            mainWindow.Show();
        }       
    }
}
