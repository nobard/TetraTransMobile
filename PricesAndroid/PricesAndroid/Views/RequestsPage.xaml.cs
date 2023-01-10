using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PricesAndroid.Models;
using PricesAndroid.ViewModels;

namespace PricesAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestsPage : ContentPage
    {
        public RequestsPage()
        {
            InitializeComponent();
            BindingContext = new RequestsViewModel();
        }
    }
}