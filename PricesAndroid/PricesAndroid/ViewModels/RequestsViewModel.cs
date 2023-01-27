using PricesAndroid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            RequestsList = App.Client.Requests;
            Task.Run(() => Refresh());
        }

        public ObservableCollection<Request> GetSearchResults(string query)
        {
            var allRequests = App.Client.Requests;

            var newList = allRequests
                .Where(e => e.SearchHelper.ToLower().Contains(query.ToLower()))
                .ToList();

            return new ObservableCollection<Request>(newList);
        }

        private async void Refresh()
        {
            var b = new List<Request>(App.Client.Requests);

            App.Client.Requests = (await App.ClientDb.GetItemAsync("user1")).Requests;
            var a = App.Client.Requests;

            if (a.Count > RequestsList.Count) RequestsList = a;

            foreach (var e in b)
            {
                if(a.Single(x => x.Id == e.Id).Status != e.Status) RequestsList = App.Client.Requests;
            }

            await Task.Delay(1000);
            Refresh();
        }
    }
}
