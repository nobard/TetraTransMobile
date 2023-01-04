using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricesAndroid.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PricesAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestsPage : ContentPage
    {
        public ObservableCollection<Request> Requests { get; set; }
        public RequestsPage()
        {
            InitializeComponent();

            Requests = new ObservableCollection<Request>
            {
                new Request(1, StatusEnum.Created, "Екатеринбург", "Бугульма", 20, 2, 20000, "15.09.22", "09.12.22"),
                new Request(2, StatusEnum.Done, "Когалым", "Сургут", 40, 3, 30000, "01.10.22", "15.11.22"),
                new Request(3, StatusEnum.InProgress, "Тюмень", "Тобольск", 20, 10, 9000, "25.09.22", "09.11.22")
            };

            RequestsListView.ItemsSource = Requests;
        }
    }
}