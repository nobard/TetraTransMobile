using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PricesAndroid.Models;

namespace PricesAndroid.Services
{
    public class ClientDataStore
    {
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
            Client client;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://192.168.0.187:7181/Api/DAL/Auth/Client?data={username}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }

            return client;
        }

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
