using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using CommunityToolkitMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityToolkitMVVM.SpecFlow.Support
{
    internal class TestingBootstrapper : Bootstrapper
    {
        public override IServiceProvider ConfigureServices()
        {
            Services.AddSingleton<IBusyStateService, BusyStateService>();
            Services.AddSingleton<IDataService<Customer>, DataService<Customer>>();
            Services.AddSingleton<ISystemDialogService, FakeSystemDialogService>();
            Services.AddTransient<MainViewModel>();
            return Services.BuildServiceProvider();
        }

    }
}
