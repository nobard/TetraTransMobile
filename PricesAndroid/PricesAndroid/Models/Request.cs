using System;
using System.Collections.Generic;
using System.Text;
using static PricesAndroid.Models.StatusEnum;

namespace PricesAndroid.Models
{
    public class Request
    {
        public int RequestNumber { get; set; }

        public StatusEnum RequestStatus { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public int ContainerSize { get; set; }

        public int CargoWeight { get; set; }

        public int Price { get; set; }

        public string DepartureDate { get; set; }

        public string RequestCreateDate { get; set; }

        public Request(int number, StatusEnum enums, string dep, string arr, int size, int weight, int price, string depd,
            string arrd)
        {
            RequestNumber = number;
            RequestStatus = enums;
            DepartureCity = dep;
            ArrivalCity = arr;
            ContainerSize = size;
            CargoWeight = weight;
            Price = price;
            DepartureDate = depd;
            RequestCreateDate = arrd;
        }
    }
}