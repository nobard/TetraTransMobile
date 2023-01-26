using PricesAndroid.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using PricesAndroid.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PricesAndroid.Services;

namespace PricesAndroid
{
    public partial class App : Application
    {
        public static Client Client { get; set; }
        public static List<string> Cities { get; set; }
        public static List<Request> AllRequests { get; set; }

        private static ClientDataStore clientDb;
        public static ClientDataStore ClientDb
        {
            get
            {
                return clientDb = clientDb ?? new ClientDataStore();
            }
        }

        private static RequestDataStore requestsDb;
        public static RequestDataStore RequestsDb
        {
            get
            {
                return requestsDb = requestsDb ?? new RequestDataStore();
            }
        }

        private static CitiesDataStore citiesDb;
        public static CitiesDataStore CitiesDb
        {
            get
            {
                return citiesDb = citiesDb ?? new CitiesDataStore();
            }
        }

        public App()
        {
            InitializeComponent();
            
            MainPage = new AppShell();
        }


        protected override async void OnStart()
        {
            //Игнор темы системы(всегда светлая)
            //Current.UserAppTheme = OSAppTheme.Light;
            Client = await ClientDb.GetItemAsync("user1");

            var cities = await CitiesDb.GetCitiesAsync();
            Cities = cities ?? new List<string>();

            var allRequests = await RequestsDb.GetAllRequestsAsync();
            AllRequests = allRequests ?? new List<Request>();
            //var list = await RequestsDb.GetRequestsAsync(Client.Id);
            //Client.Requests = new ObservableCollection<Request>(list);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
