using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.Models.Extensions;
using CommunityToolkitMVVM.Services;
using CommunityToolkitMVVM.ViewModels.Messages;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    public class CustomerViewModel : ViewModelBase, ISelectedItemViewModel<Customer>
    {
        private readonly IDataService<Customer> _dataService;
        private Customer? _customer;

        public CustomerViewModel(
            IBusyStateService busyStateService,
            IDataService<Customer> dataService)
            : base(busyStateService)
        {
            _dataService = dataService ??
                throw new ArgumentNullException(nameof(dataService));

            AddCmd = new RelayCommand(OnAdd, () => CanAdd);
            SaveCmd = new AsyncRelayCommand(OnSave, () => CanSave);
        }

        public Customer? SelectedItem
        {
            get => _customer;
            set
            {
                if (value == null && SelectedItem != null)
                {
                    SelectedItem.PropertyChanged -= OnSelectedItemPropertyChanged;
                }
                if (SetProperty(ref _customer, value))
                {
                    OnPropertyChanged(nameof(IsItemSelected));
                    if (SelectedItem != null)
                    {
                        SelectedItem.PropertyChanged += OnSelectedItemPropertyChanged;
                    }
                }
            }
        }

        public bool IsItemSelected => SelectedItem != null;

        public IRelayCommand AddCmd { get; }

        public IAsyncRelayCommand SaveCmd { get; }

        public bool CanAdd => CanExecute;

        public bool CanSave => CanExecute && IsValidCustomer;

        private bool IsValidCustomer => SelectedItem.IsValid();

        private async void OnAdd()
        {
            BusyStateService.RegisterIsBusy(nameof(OnAdd));
            SelectedItem = await _dataService.CreateAsync();
            BusyStateService.UnregisterIsBusy(nameof(OnAdd));
        }

        private async Task OnSave()
        {
            BusyStateService.RegisterIsBusy(nameof(OnSave));
            if (SelectedItem != null)
            {
                var savedAction = SavedAction._;
                if (SelectedItem.IsNullOrNew())
                {
                    await _dataService.InsertAsync(SelectedItem);
                    savedAction = SavedAction.Inserted;
                }
                else
                {
                    await _dataService.UpdateAsync(SelectedItem);
                    savedAction = SavedAction.Updated;
                }
                WeakReferenceMessenger.Default.Send(
                    new CustomerSavedMessage(savedAction, SelectedItem));
            }
            BusyStateService.UnregisterIsBusy(nameof(OnSave));
        }

        private void OnSelectedItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Customer.FirstName) ||
                e.PropertyName == nameof(Customer.Surname))
            {
                SaveCmd.NotifyCanExecuteChanged();
            }
        }

    }
}
