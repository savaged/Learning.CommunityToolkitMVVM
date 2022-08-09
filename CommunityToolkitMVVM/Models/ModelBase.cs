using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkitMVVM.Models
{
    internal abstract class ModelBase : ObservableObject, IModel
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
    }
}
