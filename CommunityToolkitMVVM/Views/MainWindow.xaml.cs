using CommunityToolkitMVVM.ViewModels;
using System.Windows;

namespace CommunityToolkitMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ILoadable vm)
            {
                await vm.LoadAsync();
            }
        }
    }
}
