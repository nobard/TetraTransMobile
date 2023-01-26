using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PricesAndroid.Models;
using Newtonsoft.Json;

namespace PricesAndroid.Services
{
    public class  RequestDataStore
    {
        private string Url = "http://192.168.0.187:5181";

        public async Task<IEnumerable<Request>> GetRequestsAsync(int clientId)
        {
            List<Request> requestsList = new List<Request>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{Url}/Api/DAL/Requests/GetAllRequestsByClientId?clientId={clientId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    requestsList = JsonConvert.DeserializeObject<List<Request>>(apiResponse);
                }
            }

            return requestsList ?? new List<Request>();
        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            List<Request> requests;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{Url}/Api/DAL/Requests/GetAllRequests"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    requests = JsonConvert.DeserializeObject<List<Request>>(apiResponse);
                }
            }

            return requests ?? new List<Request>();
        }
    }
}
