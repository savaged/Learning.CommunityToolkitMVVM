using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using CommunityToolkitMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CommunityToolkitMVVM
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            Services = new ServiceCollection();
        }

        public virtual IServiceProvider ConfigureServices()
        {
            Services.AddSingleton<IBusyStateService, BusyStateService>();
            Services.AddSingleton<IDataService<Customer>, DataService<Customer>>();
            Services.AddSingleton<ISystemDialogService, SystemDialogService>();
            Services.AddTransient<MainViewModel>();
            return Services.BuildServiceProvider();
        }

        protected IServiceCollection Services { get; }

    }
}
