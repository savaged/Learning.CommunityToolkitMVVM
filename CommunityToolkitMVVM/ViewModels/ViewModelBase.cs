using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkitMVVM.Services;
using System;
using System.ComponentModel;

namespace CommunityToolkitMVVM.ViewModels
{
    public abstract class ViewModelBase : ObservableRecipient, IBusyStateManager
    {
        protected IBusyStateService BusyStateService { get; }

        public ViewModelBase(IBusyStateService busyStateService)
        {
            BusyStateService = busyStateService ??
                throw new ArgumentNullException(nameof(busyStateService));
            BusyStateService.PropertyChanged += OnBusyStateServicePropertyChanged;
        }

        public bool IsBusy => BusyStateService.IsBusy;

        public bool IsNotBusy => !IsBusy;

        public bool CanExecute => IsNotBusy;

        private void OnBusyStateServicePropertyChanged(
            object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsBusy));
            OnPropertyChanged(nameof(IsNotBusy));
            OnPropertyChanged(nameof(CanExecute));
        }

    }
}
