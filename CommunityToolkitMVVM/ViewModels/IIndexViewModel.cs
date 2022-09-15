using CommunityToolkitMVVM.Models;
using System.Collections.Generic;

namespace CommunityToolkitMVVM.ViewModels
{
    public interface IIndexViewModel<T> : ILoadable
        where T : class, IModel
    {
        IList<T> Index { get; set; }
    }
}