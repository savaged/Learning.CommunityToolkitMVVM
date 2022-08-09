using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    internal class MainViewModel : ViewModelBase, ILoadable
    {
        public MainViewModel(IDataService<Customer> dataService)
        {
            CustomersViewModel = new CustomersViewModel(dataService);
            CustomerViewModel = new CustomerViewModel(dataService);
        }

        public async Task LoadAsync()
        {
            await CustomersViewModel.LoadAsync();
        }

        public CustomersViewModel CustomersViewModel { get; }

        public CustomerViewModel CustomerViewModel { get; }

    }
}
