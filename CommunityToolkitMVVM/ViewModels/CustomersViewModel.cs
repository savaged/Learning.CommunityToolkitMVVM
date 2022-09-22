using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Services;
using CommunityToolkitMVVM.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    public class CustomersViewModel
        : ViewModelBase, IIndexViewModel<Customer>
    {
        private readonly IDataService<Customer> _dataService;

        private IList<Customer> _index;

        public CustomersViewModel(
            IBusyStateService busyStateService,
            IDataService<Customer> dataService)
            : base(busyStateService)
        {
            _dataService = dataService ??
                throw new ArgumentNullException(nameof(dataService));

            _index = new List<Customer>();

            WeakReferenceMessenger.Default.Register<ModelSavedMessage<Customer>>(
                this, (r, m) => OnCustomerSaved(m));
        }

        public async Task LoadAsync()
        {
            BusyStateService.RegisterIsBusy(nameof(LoadAsync));
            Index = await _dataService.IndexAsync();
            BusyStateService.UnregisterIsBusy(nameof(LoadAsync));
        }

        private async void OnCustomerSaved(ModelSavedMessage<Customer> m)
        {
            if (m?.Value != null)
            {
                var index = Index.ToList();
                var match = index.FirstOrDefault(i => i.Id == m.Value.Id);
                if (match != null)
                {
                    index.Remove(match);
                }
                if (m.SavedAction != SavedAction.Deleted)
                {
                    index.Add(m.Value);
                }
                Index = index.ToList();
            }
            else
            {
                await LoadAsync();
            }
        }

        public IList<Customer> Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }


    }
}
