using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using CommunityToolkitMVVM.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    internal class CustomersViewModel : ViewModelBase, ILoadable
    {
        private readonly IDataService<Customer> _dataService;

        private IList<Customer> _index;

        public CustomersViewModel(IDataService<Customer> dataService)
        {
            _dataService = dataService ??
                throw new ArgumentNullException(nameof(dataService));

            _index = new List<Customer>();

            WeakReferenceMessenger.Default.Register<CustomerSavedMessage>(
                this, (r, m) => OnCustomerSaved(m));
        }

        public async Task LoadAsync()
        {
            Index = await _dataService.IndexAsync();
        }

        public async void OnCustomerSaved(CustomerSavedMessage m)
        {
            await LoadAsync();
        }

        public IList<Customer> Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }


    }
}
