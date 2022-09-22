using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using CommunityToolkitMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CommunityToolkitMVVM
{
    public static class Bootstrapper
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IBusyStateService, BusyStateService>();
            services.AddSingleton<IDataService<Customer>, DataService<Customer>>();
            services.AddSingleton<ISystemDialogService, SystemDialogService>();
            services.AddTransient<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
