using PricesAndroid.Models;
using PricesAndroid.Services.Interfaces;
using PricesAndroid.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PricesAndroid.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //private readonly StatusEnum status = StatusEnum.Created;

        #region PROPERTIES

        private double _totalPrice;
        private bool _isEnabledButton;
        private string _containerSize;
        private string _cargoWeight;
        private string _arrivalCity;
        private string _comment;
        private List<string> _searchResults;
        private int _listHeight;

        public double TotalPrice
        {
            get => _totalPrice;
            set => SetProperty(ref _totalPrice, value);
        }

        public bool IsEnabledButton
        {
            get => _isEnabledButton;
            set => SetProperty(ref _isEnabledButton, value);
        }

        public string ContainerSize
        {
            get => _containerSize;
            set
            {
                SetProperty(ref _containerSize, value);
                CheckRequiredFields();
            }
        }

        public string CargoWeight
        {
            get => _cargoWeight;
            set
            {
                SetProperty(ref _cargoWeight, value);
                CheckRequiredFields();
            }
        }

        public string ArrivalCity
        {
            get => _arrivalCity;
            set
            {
                SetProperty(ref _arrivalCity, value);
                CheckRequiredFields();
                SearchResults = GetSearchResults(_arrivalCity);
            }
        }

        public string Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        public List<string> SearchResults
        {
            get => _searchResults;
            set
            {
                ListHeight = (value.Count > 5 ? 5 : value.Count) * 45;
                SetProperty(ref _searchResults, value);
            }
        }

        public int ListHeight
        {
            get => _listHeight;
            set => SetProperty(ref _listHeight, value);
        }

        public DateTime MinimumDate { get; set; } = DateTime.Today;
        public DateTime DepartureDate { get; set; } = DateTime.Now;
        public string DepartureCity { get; set; } = "Екатеринбург";
        
        private int weight;
        private IDataStore<Request> requestDataStore;
        private IDataStore<string> citiesDataStore;
        private IPriceDefiner priceDefiner;
        private IEnumerable<string> cities;
        private Client user;

        #endregion

        #region COMMANDS

        private ICommand _createRequestCommand;
        public ICommand CreateRequestCommand 
            => _createRequestCommand = _createRequestCommand ?? new DelegateCommand((o) => CreateRequest());

        #endregion

        public MainViewModel(IDataStore<Request> reqDS, IDataStore<string> citiesDS, IPriceDefiner priceDef, Client user)
        {
            requestDataStore = reqDS;
            citiesDataStore = citiesDS;
            priceDefiner = priceDef;
            this.user = user;
        }

        private List<string> GetSearchResults(string query)
        {
            if (string.IsNullOrEmpty(query)) return new List<string>();

            if (cities == null)
            {
                cities = citiesDataStore.GetItemsAsync().Result;

                return new List<string>();
            }

            var newList = cities
                .Where(e => e.ToLower().Contains(query.ToLower()))
                .OrderBy(e => e.ToLower().TakeWhile(x => x != query.ToLower().First()).Count())
                .ToList();

            return newList.Count == 1 && newList.First().ToLower() == query.ToLower() ? new List<string>() : newList;
        }

        public async Task CreateRequest()
        {
            var allReq = await requestDataStore.GetItemsAsync();
            var nextId = allReq.Last().Id + 1;
            var nextNumber = allReq.Last().RequestNumber + 1;
            var today = DateTime.Today;

            var request = new Request
            {
                Id = nextId,
                RequestNumber = nextNumber,
                Status = StatusEnum.Created,
                DepartureCity = DepartureCity,
                ArrivalCity = ArrivalCity,
                ContainerSize = int.Parse(ContainerSize.Split(' ')[0]),
                CargoWeight = weight,
                Price = TotalPrice,
                DepartureDate = string.Format("{0:d2}.{1:d2}.{2}", DepartureDate.Day, DepartureDate.Month, (DepartureDate.Year % 100)),
                RequestCreateDate = string.Format("{0:d2}.{1:d2}.{2}", today.Day, today.Month, (today.Year % 100)),
                Comment = Comment,
                ClientId = user.Id
            };

            var addStatus = await requestDataStore.AddItemAsync(request);

            if (addStatus)
            {
                ClearFields();
                App.Current.MainPage.DisplayAlert("", "Спасибо за заявку! В ближайшее время с Вами свяжется наш менеджер", "Отлично!");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("", "Извините, что-то пошло не так. Попробуйте еще раз", "Закрыть!");
            }
            
        }

        private async void CheckRequiredFields()
        {
            IsEnabledButton = ContainerSize?.Length > 0 && CargoWeight?.Length > 0 && ArrivalCity?.Length > 0;

            //if user null then зарегайтесь что-то такое, но цену все равно можно увидеть. кнопку нажать нельзя

            if (IsEnabledButton)
            {
                weight = (int)double.Parse(CargoWeight); 
                TotalPrice = await priceDefiner.GetPriceAsync(weight, ArrivalCity);
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
