using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkitMVVM.Models;

namespace CommunityToolkitMVVM.ViewModels.Messages
{
    internal class CustomerSavedMessage : ValueChangedMessage<Customer>
    {
        public CustomerSavedMessage(SavedAction savedAction, Customer value) : base(value)
        {
            SavedAction = savedAction;
        }

        public SavedAction SavedAction { get; }
    }

    internal enum SavedAction
    {
        _,
        Inserted,
        Updated,
        Deleted
    }
}

