using Newtonsoft.Json;
using PricesAndroid.Models;
using PricesAndroid.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PricesAndroid.Services
{
    public class ClientDataStore : IDataStore<Client>
    {
        private string url;

        public ClientDataStore(string url)
        {
            this.url = url;
        }

        public Task<bool> AddItemAsync(Client item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetItemAsync(string username)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{url}/Api/DAL/Auth/Client?data={username}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
        }

        public async Task<Client> GetItemAsync(int id) 
            => await GetItemAsync(id.ToString());

        public Task<IEnumerable<Client>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
