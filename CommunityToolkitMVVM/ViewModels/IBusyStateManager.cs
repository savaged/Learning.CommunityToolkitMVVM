using System.ComponentModel;

namespace CommunityToolkitMVVM.ViewModels
{
    public interface IBusyStateManager : INotifyPropertyChanged
    {
        bool IsBusy { get; }
        bool IsNotBusy { get; }
    }
}