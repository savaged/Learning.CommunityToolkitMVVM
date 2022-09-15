using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace CommunityToolkitMVVM.Services
{
    public class BusyStateService : ObservableObject, IBusyStateService
    {
        private readonly IList<string> _isBusyRegister;
        private bool _isPaused;

        public BusyStateService()
        {
            _isBusyRegister = new List<string>();
        }

        public bool IsBusy => !_isPaused && _isBusyRegister.Count > 0;

        public void Pause()
        {
            _isPaused = true;
            OnPropertyChanged(nameof(IsBusy));
        }

        public void Unpause()
        {
            _isPaused = false;
            OnPropertyChanged(nameof(IsBusy));
        }

        public void RegisterIsBusy(string action)
        {
            if (action == nameof(IsBusy)) return;
            if (!_isBusyRegister.Contains(action))
                _isBusyRegister.Add(action);
            OnPropertyChanged(nameof(IsBusy));
        }

        public void UnregisterIsBusy(string action)
        {
            if (action == nameof(IsBusy)) return;
            if (_isBusyRegister.Contains(action))
                _isBusyRegister.Remove(action);
            OnPropertyChanged(nameof(IsBusy));
        }

    }
}
