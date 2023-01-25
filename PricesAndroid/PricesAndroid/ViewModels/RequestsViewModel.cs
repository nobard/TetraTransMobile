using PricesAndroid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PricesAndroid.ViewModels
{
    public class RequestsViewModel : BaseViewModel
    {
        private ObservableCollection<Request> requestsList;
        public ObservableCollection<Request> RequestsList
        {
            get => requestsList;
            set => SetProperty(ref requestsList, value);
        }

        private string searchQuery;
        public string SearchQuery
        {
            get => searchQuery;
            set
            {
                RequestsList = GetSearchResults(value);
            }
        }

        public RequestsViewModel()
        {
            RequestsList = App.Client.RequestsList;
            RequestsList = new ObservableCollection<Request>()
            {
                new Request(1, StatusEnum.Created, "Екатеринбург", "Бугульма", "20", "2", "20000", "15.09.22",
                    "09.12.22"),
                new Request(2, StatusEnum.Done, "Когалым", "Сургут", "40", "3", "30000", "01.10.22", "15.11.22"),
                new Request(3, StatusEnum.InProgress, "Тюмень", "Тобольск", "20", "10", "9000", "25.09.22", "09.11.22")
            };
        }

        public ObservableCollection<Request> GetSearchResults(string query)
        {
            //if (string.IsNullOrEmpty(query)) return new List<string>();
            var allRequests = new List<Request>()
            {
                new Request(1, StatusEnum.Created, "Екатеринбург", "Бугульма", "20", "2", "20000", "15.09.22", "09.12.22"),
                new Request(2, StatusEnum.Done, "Когалым", "Сургут", "40", "3", "30000", "01.10.22", "15.11.22"),
                new Request(3, StatusEnum.InProgress, "Тюмень", "Тобольск", "20", "10", "9000", "25.09.22", "09.11.22")
            };

            var newList = allRequests
                .Where(e => e.SearchHelper.ToLower().Contains(query.ToLower()))
                .ToList();

            return new ObservableCollection<Request>(newList);
        }
    }
}
