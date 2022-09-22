using CommunityToolkitMVVM.ViewModels;
using CommunityToolkitMVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CommunityToolkitMVVM
{
    public partial class App : Application
    {
        private IServiceProvider? _serviceProvider;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _serviceProvider = new Bootstrapper().ConfigureServices();

            Current.MainWindow = new MainWindow
            {
                DataContext = _serviceProvider?.GetService<MainViewModel>()
            };
            Current.MainWindow.Show();
        }
    }
}

