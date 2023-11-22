using PricesAndroid.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using PricesAndroid.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PricesAndroid.Utilities.RouteFactories;
using PricesAndroid.Services.Interfaces;
using PricesAndroid.ViewModels;
using PricesAndroid.Services.TetraServices;

namespace PricesAndroid
{
    public class UserChangedEventArgs
    {
        public UserInfo NewUserInfo { get; }

        public UserChangedEventArgs(UserInfo newUserInfo)
        {
            NewUserInfo = newUserInfo;
        }
    }

    public partial class App : Application
    {
        public delegate void UserChangedEventHandler(UserChangedEventArgs args);
        public static event UserChangedEventHandler UserChanged;

        private UserInfo userInfo;

        public UserInfo UserInfo
        {
            get => userInfo;
            set
            {
                if(value == userInfo) return;

                userInfo = value;
                UserChanged?.Invoke(new UserChangedEventArgs(value));
            }
        }

        public App(IAuthService authService)
        {
            InitializeComponent();

            var url = "http://192.168.0.187:5181";

            var reqDS = new RequestDataStore(url);
            var citiesDS = new CitiesDataStore(url);
            var priceDef = new PriceDefiner(url);

            Task.Run(() =>
            {
                UserInfo = clientDS.GetItemAsync(1).Result;
            });

            var builder = new ContainerBuilder();

            builder.RegisterType<RequestDataStore>().As<IDataStore<Request>>();
            builder.RegisterType<CitiesDataStore>().As<IDataStore<string>>();

            var mainPageFac = new MainPageRouteFactory(new MainViewModel(reqDS, citiesDS, priceDef));
            var reqFac = new RequestsPageRouteFactory(new RequestsViewModel());
            var userFac = new UserProfilePageRouteFactory(new UserProfileViewModel());
            
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
