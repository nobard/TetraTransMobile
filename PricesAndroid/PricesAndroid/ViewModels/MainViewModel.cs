using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PricesAndroid.Models;
using PricesAndroid.Utilities;
using Xamarin.Forms;

namespace PricesAndroid.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly StatusEnum status = StatusEnum.Created;
        public DateTime MinimumDate { get; set; } = DateTime.Today;
        public DateTime DepartureDate { get; set; } = DateTime.Now;
        public string DepartureCity { get; set; } = "Екатеринбург";
        private List<string> Cities { get; set; } = new List<string>();
        private int weight;

        private int totalPrice;
        public int TotalPrice
        {
            get => totalPrice;
            set => SetProperty(ref totalPrice, value);
        }

        private bool isEnabledButton;
        public bool IsEnabledButton
        {
            get => isEnabledButton;
            set => SetProperty(ref isEnabledButton, value);
        }

        private string containerSize;
        public string ContainerSize
        {
            get => containerSize;
            set
            {
                SetProperty(ref containerSize, value);
                CheckRequiredFields();
            }
        }

        private string cargoWeight;
        public string CargoWeight
        {
            get => cargoWeight;
            set
            {
                SetProperty(ref cargoWeight, value);
                CheckRequiredFields();
            }
        }

        private string arrivalCity;
        public string ArrivalCity
        {
            get => arrivalCity;
            set
            {
                SetProperty(ref arrivalCity, value);
                CheckRequiredFields();
                SearchResults = GetSearchResults(arrivalCity);
            }
        }

        private string comment;
        public string Comment
        {
            get => comment;
            set => SetProperty(ref comment, value);
        }

        private List<string> searchResults;
        public List<string> SearchResults
        {
            get => searchResults;
            set
            {
                ListHeight = (value.Count > 5 ? 5 : value.Count) * 45;
                SetProperty(ref searchResults, value);
            }
        }

        private int listHeight;
        public int ListHeight
        {
            get => listHeight;
            set => SetProperty(ref listHeight, value);
        }

        #region COMMANDS

        private ICommand createRequestCommand;
        public ICommand CreateRequestCommand
        {
            get
            {
                return createRequestCommand = createRequestCommand ?? new DelegateCommand((o) => CreateRequest());
            }
        }

        #endregion

        public List<string> GetSearchResults(string query)
        {
            if (string.IsNullOrEmpty(query)) return new List<string>();

            var all = App.Cities;

            var newList = all
                .Where(e => e.ToLower().Contains(query.ToLower()))
                .OrderBy(e => e.ToLower().TakeWhile(x => x != query.ToLower().First()).Count())
                .ToList();

            return newList.Count == 1 && newList.First().ToLower() == query.ToLower() ? new List<string>() : newList;
        }

        public async Task CreateRequest()
        {
            var message = "Спасибо за заявку! В ближайшее время с Вами свяжется наш менеджер";
            var nextId = App.AllRequests.Last().Id + 1;
            var nextNumber = App.AllRequests.Last().RequestNumber + 1;
            var today = DateTime.Today;

            var request = new Request
            {
                Id = nextId,
                RequestNumber = nextNumber,
                Status = status,
                DepartureCity = DepartureCity,
                ArrivalCity = ArrivalCity,
                ContainerSize = int.Parse(ContainerSize.Split(' ')[0]),
                CargoWeight = weight,
                Price = TotalPrice,
                DepartureDate = String.Format("{0:d2}.{1:d2}.{2}", DepartureDate.Day, DepartureDate.Month, (DepartureDate.Year % 100)),
                RequestCreateDate = String.Format("{0:d2}.{1:d2}.{2}", today.Day, today.Month, (today.Year % 100)),
                Comment = Comment ?? "",
                ClientId = App.Client.Id
            };


            var requestDomain = new RequestDomain
            {
                Id = nextId,
                RequestNumber = nextNumber,
                Status = status,
                DepartureCity = DepartureCity,
                ArrivalCity = ArrivalCity,
                ContainerSize = int.Parse(ContainerSize.Split(' ')[0]),
                CargoWeight = weight,
                Price = TotalPrice,
                DepartureDate = String.Format("{0:d2}.{1:d2}.{2}", DepartureDate.Day, DepartureDate.Month, (DepartureDate.Year % 100)),
                RequestCreateDate = String.Format("{0:d2}.{1:d2}.{2}", today.Day, today.Month, (today.Year % 100)),
                Comment = Comment ?? "",
                ClientId = App.Client.Id,
            };

            App.Client.Requests.Add(request);
            App.AllRequests.Add(request);
            await App.RequestsDb.AddRequestAsync(requestDomain);
            ClearFields();
            App.Current.MainPage.DisplayAlert("", message, "Отлично!");
        }

        private async void CheckRequiredFields()
        {
            IsEnabledButton = ContainerSize?.Length > 0 && CargoWeight?.Length > 0 && ArrivalCity?.Length > 0;
            if (IsEnabledButton)
            {
                weight = (int)double.Parse(CargoWeight); 
                TotalPrice = await App.CitiesDb.GetSumAsync(weight, ArrivalCity);
            }
        }

        private void ClearFields()
        {
            ContainerSize = string.Empty;
            CargoWeight = string.Empty;
            ArrivalCity = string.Empty;
            Comment = string.Empty;
            DepartureDate = DateTime.Now;
            TotalPrice = 0;
        }
    }
}
