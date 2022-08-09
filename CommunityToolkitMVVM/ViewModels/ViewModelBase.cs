using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkitMVVM.ViewModels
{
    internal abstract class ViewModelBase : ObservableRecipient
    {
        public bool IsBusy => false; // TODO implement this

        public bool CanExecute => !IsBusy;
    }
}
