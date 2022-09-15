using System.Threading.Tasks;

namespace CommunityToolkitMVVM.ViewModels
{
    public interface ILoadable
    {
        Task LoadAsync();
    }
}
