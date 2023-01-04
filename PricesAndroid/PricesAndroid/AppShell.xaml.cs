using PricesAndroid.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PricesAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Задаем стартовую страницу
            CurrentItem = Estimation;

            Routing.RegisterRoute(nameof(RequestsPage), typeof(RequestsPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(UserProfilePage), typeof(UserProfilePage));
        }
    }
}