using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricesAndroid.Models;
using PricesAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PricesAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
            BindingContext = new UserProfileViewModel();
        }
    }
}