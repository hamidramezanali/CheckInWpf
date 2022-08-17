using CheckInWpf.Service;
using CheckInWpf.Soters;
using CheckInWpf.ViewModel;
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

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fa-Ir");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var host = Host.CreateDefaultBuilder()
    .ConfigureServices(ConfigureServices)
    .Build();
            IFileService fileService=host.Services.GetRequiredService<IFileService>();
            IDbService dbService = host.Services.GetRequiredService<IDbService>();       
            ICheckInService checkInService = host.Services.GetRequiredService<ICheckInService>();
            NavigationStore navigationStore = host.Services.GetRequiredService<NavigationStore>();

            fileService.InitializeFiles();
            dbService.InitializeDb();

            navigationStore.CurrentViewModel = host.Services.GetRequiredService<CheckedInListViewModel>();
            MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();

            mainWindow.DataContext= host.Services.GetRequiredService<MainWindowViewModel>();
            mainWindow.Show();
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
