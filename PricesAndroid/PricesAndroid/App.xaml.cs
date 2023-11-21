using PricesAndroid.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using PricesAndroid.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PricesAndroid.Services;
using PricesAndroid.Utilities.RouteFactories;
using PricesAndroid.Services.Interfaces;
using PricesAndroid.ViewModels;

namespace PricesAndroid
{
    public partial class App : Application
    {
        //public static Client Client { get; set; }
        //public static List<string> Cities { get; set; }
        //public static List<Request> AllRequests { get; set; }

        //private static ClientDataStore clientDb;
        //public static ClientDataStore ClientDb
        //{
        //    get
        //    {
        //        return clientDb = clientDb ?? new ClientDataStore();
        //    }
        //}

        //private static RequestDataStore requestsDb;
        //public static RequestDataStore RequestsDb
        //{
        //    get
        //    {
        //        return requestsDb = requestsDb ?? new RequestDataStore();
        //    }
        //}

        //private static CitiesDataStore citiesDb;
        //public static CitiesDataStore CitiesDb
        //{
        //    get
        //    {
        //        return citiesDb = citiesDb ?? new CitiesDataStore();
        //    }
        //}

        public App()
        {

            InitializeComponent();

            var url = "http://192.168.0.187:5181";


            var reqDS = new RequestDataStore(url);
            var userDS = new ClientDataStore(url);
            var citiesDS = new CitiesDataStore(url);
            var priceDef = new PriceDefiner(url);
            var client = new Client();


            var builder = new ContainerBuilder();

            builder.RegisterType<RequestDataStore>().As<IDataStore<Request>>();
            builder.RegisterType<CitiesDataStore>().As<IDataStore<string>>();

            var mainPageFac = new MainPageRouteFactory(new MainViewModel(reqDS, citiesDS, priceDef, client));
            var reqFac = new RequestsPageRouteFactory(new RequestsViewModel(client));
            var userFac = new UserProfilePageRouteFactory(new UserProfileViewModel(client));
            
            MainPage = new AppShell(mainPageFac, reqFac, userFac);
        }

        protected override async void OnStart()
        {
            //Игнор темы системы(всегда светлая)
            Current.UserAppTheme = OSAppTheme.Light;

            //Client = await ClientDb.GetItemAsync("user1");

            //var cities = await CitiesDb.GetCitiesAsync();
            //Cities = cities ?? new List<string>();

            //var allRequests = await RequestsDb.GetAllRequestsAsync();
            //AllRequests = allRequests ?? new List<Request>();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
