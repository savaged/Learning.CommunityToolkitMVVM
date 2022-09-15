using CommunityToolkitMVVM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.Services
{
    public interface IDataService<T> where T : IModel, new()
    {
        Task<T> CreateAsync();
        Task<int> InsertAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int id);
        Task<IList<T>> IndexAsync();
    }
}