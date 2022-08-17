using CheckInWpf.Service;
using CheckInWpf.Soters;
using CheckInWpf.ViewModel;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private  IFileService fileService;
        private  IDbService dbService;
        private  ICheckInService checkInService;
        private IOrderNumberService orderNumberService;
        private  NavigationStore navigationStore;

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fa-Ir");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var host = Host.CreateDefaultBuilder()
    .ConfigureServices(ConfigureServices)
    .Build();
             fileService=host.Services.GetRequiredService<IFileService>();
             dbService = host.Services.GetRequiredService<IDbService>();       
             checkInService = host.Services.GetRequiredService<ICheckInService>();
            orderNumberService= host.Services.GetRequiredService<IOrderNumberService>();
             navigationStore = host.Services.GetRequiredService<NavigationStore>();

            fileService.InitializeFiles();
            dbService.InitializeDb();

            navigationStore.CurrentViewModel = new CheckedInListViewModel(checkInService, navigationStore, CreateMakeOrderCommand);
            
            MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();

            mainWindow.DataContext= host.Services.GetRequiredService<MainWindowViewModel>();
            mainWindow.Show();
        }

        private ViewModelBase CreateMakeOrderCommand()
        {
            return new CheckInCreatorViewModel(orderNumberService, checkInService, navigationStore, CreateCheckedInListViewModel);
        }

        private ViewModelBase CreateCheckedInListViewModel ()
        {
            return new CheckedInListViewModel(checkInService, navigationStore, CreateMakeOrderCommand);

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<App>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IDbService, DbService>();
            services.AddSingleton<ICheckInService, CheckInService>();
            services.AddSingleton<IOrderNumberService, OrderNumberService>();
            services.AddSingleton<ICheckInService, CheckInService>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<CheckedInListViewModel>();
            services.AddSingleton<CheckInCreatorViewModel>();
            services.AddSingleton<MainWindowViewModel>();



        }
    }
}
