using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PricesAndroid.Models;

namespace PricesAndroid.Services
{
    public class ClientDataStore
    {
        private string url = "http://192.168.0.187:5181";

        public async Task<Client> GetItemAsync(string username)
        {
            Client client;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{url}/Api/DAL/Auth/Client?data={username}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }

            return client;
        }
    }
}
