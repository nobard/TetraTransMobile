﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PricesAndroid.Models;
using Newtonsoft.Json;

namespace PricesAndroid.Services
{
    public class  RequestDataStore : IDataStore<Request>
    {
        readonly List<Request> requests;
        private string Url = "http://192.168.0.187:5181/";

        public RequestDataStore()
        {
            requests = new List<Request>()
            {
                //new Request(1, StatusEnum.Created, "Екатеринбург", "Бугульма", 20, 2, 20000, "15.09.22", "09.12.22"),
                //new Request(2, StatusEnum.Done, "Когалым", "Сургут", 40, 3, 30000, "01.10.22", "15.11.22"),
                //new Request(3, StatusEnum.InProgress, "Тюмень", "Тобольск", 20, 10, 9000, "25.09.22", "09.11.22")
            };
        }

        public async Task<bool> AddItemAsync(Request item)
        {
            //TODO
            requests.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Request item)
        {
            //TODO
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            //TODO
            return await Task.FromResult(true);
        }

        public async Task<Request> GetItemAsync(int id)
        {
            //TODO
            return await Task.FromResult(requests.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Request>> GetItemsAsync(bool forceRefresh = false)
        {
            //TODO
            
            return await Task.FromResult(requests);
        }

        public async Task<IEnumerable<Request>> GetRequestsAsync(int id)
        {
            List<Request> requestsList;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{Url}Api/DAL/Requests/GetAllRequestsByClientId?clientId={id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    requestsList = JsonConvert.DeserializeObject<List<Request>>(apiResponse);
                }
            }

            return requestsList;
        }
    }
}