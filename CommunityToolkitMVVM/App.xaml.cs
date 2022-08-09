using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using CommunityToolkitMVVM.ViewModels;
using CommunityToolkitMVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CommunityToolkitMVVM
{
    public partial class App : Application
    {
        private IServiceProvider? _services;

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDataService<Customer>, DataService<Customer>>();
            services.AddTransient<MainViewModel>();

            return services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _services = ConfigureServices();

            Current.MainWindow = new MainWindow
            {
                DataContext = _services?.GetService<MainViewModel>()
            };
            Current.MainWindow.Show();
        }
    }
}

