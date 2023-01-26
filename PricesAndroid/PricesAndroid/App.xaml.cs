using PricesAndroid.Views;
using System;
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

        private static ClientDataStore clientDb;
        public static ClientDataStore ClientDb
        {
            get
            {
                return clientDb = clientDb ?? new ClientDataStore();
            }
        }

        private static RequestDataStore requestsDb;
        //public static RequestsDataStore RequestsDb
        //{
        //    get
        //    {
        //        //return requestsDb = requestsDb ?? new RequestsDataStore(Path.Combine(
        //            //Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ServicesDatabase.db3"));
        //    }
        //}

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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
