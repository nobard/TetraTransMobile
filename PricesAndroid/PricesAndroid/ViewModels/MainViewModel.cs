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

        private string containerSize;
        public string ContainerSize
        {
            get => containerSize;
            set => SetProperty(ref containerSize, value);
        }

        private string cargoWeight;
        public string CargoWeight
        {
            get => cargoWeight;
            set => SetProperty(ref cargoWeight, value);
        }

        public string DepartureCity { get; set; } = "ЕКАТЕРИНБУРГ";

        private string arrivalCity;
        public string ArrivalCity
        {
            get => arrivalCity;
            set => SetProperty(ref arrivalCity, value);
        }

        public string DepartureDate { get; set; }

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
            if (CheckRequiredFields())
            {
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
                    DepartureDate = DateTime.ParseExact(DepartureDate, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToShortDateString(),
                    RequestCreateDate = DateTime.Today.ToShortDateString(),
                    Comment = Comment
                };

                App.UserInfo.RequestsList.Add(request);
                ClearFields();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("", "Не все поля заполнены", "OK");
            }

            
        }
        private bool CheckRequiredFields()
        {
            //datepicker propertychanged ? ok : showallert(datu viberi)
            return true;
        }

        private void ClearFields()
        {
            ContainerSize = string.Empty;
            CargoWeight = string.Empty;
            ArrivalCity = string.Empty;
            Comment = string.Empty;
            DepartureDate = string.Empty;
        }
    }
}
