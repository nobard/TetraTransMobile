using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PricesAndroid.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace PricesAndroid.Services
{
    public class  RequestDataStore
    {
        private string url = "http://192.168.0.187:5181";

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            List<Request> requests;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{url}/Api/DAL/Requests/GetAllRequests"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    requests = JsonConvert.DeserializeObject<List<Request>>(apiResponse);
                }
            }

            return requests ?? new List<Request>();
        }

        public async Task AddRequestAsync(RequestDomain req)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync($"{url}/Api/DAL/Requests/AddRequest", req))
                {
                    string apiResponse = await response?.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
