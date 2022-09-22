using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    public class MainViewModel
        : ViewModelBase, IIndexAndSelectedItemViewModel<Customer>
    {
        public MainViewModel(
            IBusyStateService busyStateService,
            IDataService<Customer> dataService,
            ISystemDialogService systemDialogService)
            : base(busyStateService)
        {
            IndexViewModel =
                new CustomersViewModel(busyStateService, dataService);
            SelectedItemViewModel = new CustomerViewModel(
                busyStateService, dataService, systemDialogService);
        }

        public async Task LoadAsync()
        {
            BusyStateService.RegisterIsBusy(nameof(LoadAsync));
            await IndexViewModel.LoadAsync();
            BusyStateService.UnregisterIsBusy(nameof(LoadAsync));
        }

        public IIndexViewModel<Customer> IndexViewModel { get; }

        public ISelectedItemViewModel<Customer> SelectedItemViewModel { get; }

    }
}
