using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkitMVVM.Models;

namespace CommunityToolkitMVVM.ViewModels.Messages
{
    public class ModelSavedMessage<T> : ValueChangedMessage<T>
        where T : class, IModel
    {
        public ModelSavedMessage(SavedAction savedAction, T model)
            : base(model)
        {
            SavedAction = savedAction;
        }

        public SavedAction SavedAction { get; }
    }

    public enum SavedAction
    {
        _,
        Inserted,
        Updated,
        Deleted
    }
}

