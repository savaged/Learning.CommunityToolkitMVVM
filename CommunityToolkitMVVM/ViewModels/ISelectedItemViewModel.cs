using CommunityToolkit.Mvvm.Input;
using CommunityToolkitMVVM.Models;

namespace CommunityToolkitMVVM.ViewModels
{
    public interface ISelectedItemViewModel<T>
        where T : class, IModel, new()
    {
        IAsyncRelayCommand AddCmd { get; }
        bool CanAdd { get; }
        bool CanSave { get; }
        bool IsItemSelected { get; }
        IAsyncRelayCommand SaveCmd { get; }
        IAsyncRelayCommand DeleteCmd { get; }
        T? SelectedItem { get; set; }
    }
}