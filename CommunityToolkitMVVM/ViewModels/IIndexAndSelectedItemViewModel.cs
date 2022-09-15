using CommunityToolkitMVVM.Models;

namespace CommunityToolkitMVVM.ViewModels
{
    public interface IIndexAndSelectedItemViewModel<T>
        where T : class, IModel, new()
    {
        IIndexViewModel<T> IndexViewModel { get; }
        ISelectedItemViewModel<T> SelectedItemViewModel { get; }
    }
}