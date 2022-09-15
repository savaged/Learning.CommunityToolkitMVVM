using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    internal class MainViewModel : ViewModelBase, ILoadable
    {
        public MainViewModel(
            IBusyStateService busyStateService,
            IDataService<Customer> dataService)
            : base(busyStateService)
        {
            CustomersViewModel =
                new CustomersViewModel(busyStateService, dataService);
            CustomerViewModel =
                new CustomerViewModel(busyStateService, dataService);
        }

        public async Task LoadAsync()
        {
            BusyStateService.RegisterIsBusy(nameof(LoadAsync));
            await CustomersViewModel.LoadAsync();
            BusyStateService.UnregisterIsBusy(nameof(LoadAsync));
        }

        public CustomersViewModel CustomersViewModel { get; }

        public CustomerViewModel CustomerViewModel { get; }

    }
}
