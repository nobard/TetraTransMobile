using Newtonsoft.Json;
using PricesAndroid.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PricesAndroid.Services
{
    public class CitiesDataStore
    {
        private string url = "http://192.168.0.187:5181";

        public async Task<List<string>> GetCitiesAsync()
        {
            List<string> cities;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{url}/Api/DAL/Stavki/GetAllPuncts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cities = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                }
            }

            return cities ?? new List<string>();
        }

        public async Task<int> GetSumAsync(int weight, string city)
        {
            int sum;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{url}/Api/DAL/Requests/GetRequestSum?weight={weight}&city={city}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sum = JsonConvert.DeserializeObject<int>(apiResponse);
                }
            }

            return sum;
        }
    }
}
