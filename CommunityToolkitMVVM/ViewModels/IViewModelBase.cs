using System.ComponentModel;

namespace CommunityToolkitMVVM.ViewModels
{
    internal interface IBusyStateManager : INotifyPropertyChanged
    {
        bool IsBusy { get; }
        bool IsNotBusy { get; }
    }
}