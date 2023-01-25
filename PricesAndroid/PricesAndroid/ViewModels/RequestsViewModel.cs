using PricesAndroid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PricesAndroid.ViewModels
{
    public class RequestsViewModel : BaseViewModel
    {
        public ObservableCollection<Request> RequestsList { get; set; }

        public RequestsViewModel()
        {
            RequestsList = App.Client.RequestsList;
        }
    }
}
