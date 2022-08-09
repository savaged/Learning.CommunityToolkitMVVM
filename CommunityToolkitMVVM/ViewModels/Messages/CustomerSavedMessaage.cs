using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkitMVVM.Models;

namespace CommunityToolkitMVVM.ViewModels.Messages
{
    internal class CustomerSavedMessage : ValueChangedMessage<Customer>
    {
        public CustomerSavedMessage(Customer value) : base(value)
        {
        }
    }
}

