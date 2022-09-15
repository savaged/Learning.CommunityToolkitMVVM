using CommunityToolkit.Mvvm.Input;
using CommunityToolkitMVVM.Models;

namespace CommunityToolkitMVVM.ViewModels
{
    public interface ISelectedItemViewModel<T>
        where T : class, IModel, new()
    {
        IRelayCommand AddCmd { get; }
        bool CanAdd { get; }
        bool CanSave { get; }
        bool IsItemSelected { get; }
        IAsyncRelayCommand SaveCmd { get; }
        T? SelectedItem { get; set; }
    }
}