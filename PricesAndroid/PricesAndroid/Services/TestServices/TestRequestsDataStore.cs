using PricesAndroid.Models;
using PricesAndroid.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricesAndroid.Services.TestServices
{
    internal class TestRequestsDataStore : IDataStore<Request>
    {
        public Task<bool> AddItemAsync(Request item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Request item)
        {
            throw new NotImplementedException();
        }
    }
}
