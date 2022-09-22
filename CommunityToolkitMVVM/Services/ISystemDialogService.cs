using System;

namespace CommunityToolkitMVVM.Services
{
    public interface ISystemDialogService
    {
        void Show(Exception ex);
        void Show(string message);
        bool ShowConfirmation(string message = "Are you sure?", string title = "Confirm");
        string? ShowOpenFileDialog(string? title = null, string? initialDirectory = null, string? fileFilter = null, string? filename = null);
    }
}