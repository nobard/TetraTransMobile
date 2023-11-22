using PricesAndroid.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricesAndroid.Services.TestServices
{
    internal class TestCitiesDataStore : IDataStore<string>
    {
        public Task<bool> AddItemAsync(string item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(string item)
        {
            throw new NotImplementedException();
        }
    }
}
