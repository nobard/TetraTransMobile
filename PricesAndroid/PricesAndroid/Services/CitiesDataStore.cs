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
        static HttpClient httpPostClient = new HttpClient();
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

            return cities = cities ?? new List<string>();
        }

        public async Task<int> GetSumAsync(int weight, string city)
        {
            int sum;

            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.PostAsync($"{url}/Api/DAL/Requests/GetRequestSum?weight={weight}&city={city}", ))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        sum = JsonConvert.DeserializeObject<int>(apiResponse);
            //    }
            //}

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{url}/Api/DAL/Requests/GetRequestSum?weight={weight}&city={city}"))
            {
                using (var response = await httpPostClient.SendAsync(request))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sum = int.Parse(apiResponse);
                }
            }
            //TODO
            //пуш новой заявки
            //исправить дату одной заявки (БД)
            //исправить энамы(БД)
            //исправить футы в заявке


            return sum;
        }
    }
}
