using PricesAndroid.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PricesAndroid
{
    public partial class App : Application
    {
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
