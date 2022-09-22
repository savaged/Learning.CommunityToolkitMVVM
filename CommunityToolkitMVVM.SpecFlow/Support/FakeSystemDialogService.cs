using CommunityToolkitMVVM.Services;

namespace CommunityToolkitMVVM.SpecFlow.Support
{
    internal class FakeSystemDialogService : ISystemDialogService
    {
        private Action<string>? _messageSetter;

        public void Init(Action<string> messageSetter)
        {
            _messageSetter = messageSetter ??
                throw new ArgumentNullException(nameof(messageSetter));
        }

        public void Show(Exception ex)
        {
            if (_messageSetter == null)
                throw new InvalidOperationException($"Call {nameof(Init)} first!");
            _messageSetter(ex.Message);
        }

        public void Show(string message)
        {
            if (_messageSetter == null)
                throw new InvalidOperationException($"Call {nameof(Init)} first!");
            _messageSetter(message);
        }

        public bool ShowConfirmation(string message = "Are you sure?", string title = "Confirm")
        {
            if (_messageSetter == null)
                throw new InvalidOperationException($"Call {nameof(Init)} first!");
            _messageSetter(message);
            return true;
        }

        public string? ShowOpenFileDialog(
            string? title = null,
            string? initialDirectory = null,
            string? fileFilter = null,
            string? filename = null)
        {
            throw new NotImplementedException();
        }

    }
}
