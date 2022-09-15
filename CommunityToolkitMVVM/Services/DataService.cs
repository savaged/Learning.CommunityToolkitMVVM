using CommunityToolkitMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityToolkitMVVM.Services
{
    internal class DataService<T> : IDataService<T>
        where T : IModel, new()
    {
        private readonly IDictionary<int, T> _data;

        public DataService()
        {
            _data = new Dictionary<int, T>();
        }

        public async Task<T> CreateAsync()
        {
            await EmulateAsynchronousRunning();

            return new T();
        }

        public async Task<int> InsertAsync(T model)
        {
            await EmulateAsynchronousRunning();

            var id = _data.Count + 1;
            _data.Add(id, model);
            return id;
        }

        public async Task UpdateAsync(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await EmulateAsynchronousRunning();

            if (_data.ContainsKey(model.Id))
            {
                _data[model.Id] = model;
            }
            else
            {
                throw new InvalidOperationException($"{model.Id} does not exist");
            }
        }

        public async Task DeleteAsync(int id)
        {
            await EmulateAsynchronousRunning();

            if (_data.ContainsKey(id))
            {
                _data.Remove(id);
            }
        }

        public async Task<IList<T>> IndexAsync()
        {
            await EmulateAsynchronousRunning();

            return _data.Values.ToList();
        }

        private async Task EmulateAsynchronousRunning()
        {
            await Task.Delay(1000);
        }

    }
}
