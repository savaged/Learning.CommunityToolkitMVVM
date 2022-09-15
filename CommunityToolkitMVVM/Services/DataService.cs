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
            if (model == null) return 0;

            await EmulateAsynchronousRunning();
            var id = _data.Count + 1;
            _data.Add(id, model);
            model.Id = id;
            return id;
        }

        public async Task UpdateAsync(T model)
        {
            if (model == null) return;

            if (_data.ContainsKey(model.Id))
            {
                await EmulateAsynchronousRunning();
                _data[model.Id] = model;
            }
            else
            {
                throw new InvalidOperationException($"{model.Id} does not exist");
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (_data.ContainsKey(id))
            {
                await EmulateAsynchronousRunning();
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
