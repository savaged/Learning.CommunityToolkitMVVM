using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace CommunityToolkitMVVM.Services
{
    public class SystemDialogService : ISystemDialogService
    {
        public void Show(string message)
        {
            MessageBox.Show(
                    message,
                    "Information",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }

        public bool ShowConfirmation(string message = "Are you sure?", string title = "Confirm")
        {
            var confirmation = MessageBox.Show(
                message,
                title,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            return confirmation == MessageBoxResult.Yes;
        }

        public void Show(Exception ex)
        {
            MessageBox.Show(
                    $"{ex?.Message}{Environment.NewLine}{ex?.InnerException?.Message}",
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        public string? ShowOpenFileDialog(
            string? title = null,
            string? initialDirectory = null,
            string? fileFilter = null,
            string? filename = null)
        {
            var initialDir = initialDirectory ??
                    Path.GetFullPath(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            var dialog = new OpenFileDialog
            {
                Title = title,
                InitialDirectory = initialDir,
                Filter = fileFilter,
                FileName = filename
            };
            var result = dialog.ShowDialog();
            if (result == true)
            {
                filename = dialog.FileName;
            }
            return filename;
        }

    }
}
