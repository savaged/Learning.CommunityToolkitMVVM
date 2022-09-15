using System.ComponentModel;

namespace CommunityToolkitMVVM.Services
{
    public interface IBusyStateService : INotifyPropertyChanged
    {
        bool IsBusy { get; }

        void Pause();
        void RegisterIsBusy(string action);
        void Unpause();
        void UnregisterIsBusy(string action);
    }
}