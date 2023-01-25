using System;
using System.Collections.Generic;
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

        public string DepartureCity { get; set; } = "ЕКАТЕРИНБУРГ";

        private string arrivalCity;
        public string ArrivalCity
        {
            get => arrivalCity;
            set
            {
                SetProperty(ref arrivalCity, value);
                CheckRequiredFields();
            }
        }

        public DateTime DepartureDate { get; set; } = DateTime.Now;

        private string comment;
        public string Comment
        {
            get => comment;
            set => SetProperty(ref comment, value);
        }

        
        public string TotalPrice { get; set; }

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

        public void CreateRequest()
        {
            var message = "Спасибо за заявку! В ближайшее время с Вами свяжется наш менеджер";
            var request = new Request
            {
                //Id = bd
                //RequestNumber = bd
                RequestStatus = status,
                DepartureCity = DepartureCity,
                ArrivalCity = ArrivalCity,
                ContainerSize = ContainerSize,
                CargoWeight = CargoWeight,
                //Price = bd TotalPrice
                //DepartureDate = DateTime.ParseExact(DepartureDate, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToShortDateString(),
                DepartureDate = DepartureDate.ToShortDateString(),
                RequestCreateDate = DateTime.Today.ToShortDateString(),
                Comment = Comment
            };

            App.Client.RequestsList.Add(request);
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
