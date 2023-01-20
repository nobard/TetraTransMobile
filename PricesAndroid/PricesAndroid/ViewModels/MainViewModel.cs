using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using PricesAndroid.Models;
using PricesAndroid.Utilities;
using Xamarin.Forms;

namespace PricesAndroid.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Request NewRequest { get; set; }

        private readonly StatusEnum status = StatusEnum.Created;

        //public string ContainerSize { get; set; }

        //public string CargoWeight { get; set; }

        public string DepartureCity { get; set; } = "ЕКАТЕРИНБУРГ";

        //public string ArrivalCity { get; set; }

        //public string DepartureDate { get; set; }

        //public string Comment { get; set; }

        public string TotalPrice { get; set; }

        public MainViewModel()
        {
            NewRequest = new Request();
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

        public void CreateRequest()
        {
            var request = new Request
            {
                //Id = bd
                //RequestNumber = bd
                RequestStatus = status,
                DepartureCity = DepartureCity,
                ArrivalCity = NewRequest.ArrivalCity,
                ContainerSize = NewRequest.ContainerSize,
                CargoWeight = NewRequest.CargoWeight,
                //Price = bd TotalPrice
                DepartureDate = NewRequest.DepartureDate,
                RequestCreateDate = DateTime.Today.ToShortDateString(),
                Comment = NewRequest.Comment
            };

            App.UserInfo.RequestsList.Add(request);
            ClearFields();
        }
        private void CheckRequiredFields()
        {

        }

        private void ClearFields()
        {
            //TODO поменять обратно на поля и чистить их
            NewRequest = new Request();
        }
    }
}
