using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    internal interface ILoadable
    {
        Task LoadAsync();
    }
}
