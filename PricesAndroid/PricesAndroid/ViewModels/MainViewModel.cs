using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        public string DepartureCity { get; set; } = "ЕКАТЕРИНБУРГ";
        public string TotalPrice { get; set; }

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
            var all = new List<string>
                { "Когалым", "Екатеринбург", "Тюмень", "Тобольск", "Курган", "Кушва", "Уренгой" };

            var newList = all
                .Where(e => e.ToLower().Contains(query.ToLower()))
                .OrderBy(e => e.ToLower().TakeWhile(x => x != query.ToLower().First()).Count())
                .ToList();

            return newList.Count == 1 && newList.First().ToLower() == query.ToLower() ? new List<string>() : newList;
        }

        public void CreateRequest()
        {
            var message = "Спасибо за заявку! В ближайшее время с Вами свяжется наш менеджер";
            //var request = new Request
            //{
            //    //Id = bd
            //    //RequestNumber = bd
            //    RequestStatus = status,
            //    DepartureCity = DepartureCity,
            //    ArrivalCity = ArrivalCity,
            //    ContainerSize = ContainerSize,
            //    CargoWeight = CargoWeight,
            //    //Price = bd TotalPrice
            //    //DepartureDate = DateTime.ParseExact(DepartureDate, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToShortDateString(),
            //    DepartureDate = DepartureDate.ToShortDateString(),
            //    RequestCreateDate = DateTime.Today.ToShortDateString(),
            //    Comment = Comment
            //};

            //App.Client.RequestsList.Add(request);
            ClearFields();
            App.Current.MainPage.DisplayAlert("", message, "Отлично!");
        }

        private void CheckRequiredFields()
        {
            IsEnabledButton = ContainerSize?.Length > 0 && CargoWeight?.Length > 0 && ArrivalCity?.Length > 0;
            if (IsEnabledButton)
            {
                //посчитать и вывести цену TotalPrice = бд
            }
        }

        private void ClearFields()
        {
            ContainerSize = string.Empty;
            CargoWeight = string.Empty;
            ArrivalCity = string.Empty;
            Comment = string.Empty;
            DepartureDate = DateTime.Now;
        }
    }
}
