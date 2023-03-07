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
        }

        public ObservableCollection<Request> GetSearchResults(string query)
        {
            var allRequests = App.Client.Requests;

            var newList = allRequests
                .Where(e => e.SearchHelper.ToLower().Contains(query.ToLower()))
                .ToList();

            return new ObservableCollection<Request>(newList);
        }
    }
}
