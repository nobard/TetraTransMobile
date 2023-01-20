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
        private static User userInfo;

        public static User UserInfo
        {
            get
            {
                return userInfo = userInfo ?? new User();
            }
        }

        private static RequestsDataStore requestsDb;

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


        protected override void OnStart()
        {
            //Игнор темы системы(всегда светлая)
            //Current.UserAppTheme = OSAppTheme.Light;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
