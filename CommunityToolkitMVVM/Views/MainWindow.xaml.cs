using CommunityToolkitMVVM.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CommunityToolkitMVVM.Views
{
    public partial class MainWindow : Window
    {
        private IBusyStateManager _busyStateManager;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IBusyStateManager bsm)
            {
                _busyStateManager = bsm;
                _busyStateManager.PropertyChanged += OnBusyStateManagerPropertyChanged;
            }
            if (DataContext is ILoadable l)
            {
                await l.LoadAsync();
            }
        }

        private void OnBusyStateManagerPropertyChanged(
            object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IBusyStateManager.IsBusy))
            {
                Mouse.OverrideCursor = _busyStateManager.IsBusy ? Cursors.Wait : null;
            }
        }

    }
}
