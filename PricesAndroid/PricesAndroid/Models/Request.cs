using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using static PricesAndroid.Models.StatusEnum;

namespace PricesAndroid.Models
{
    public class Request : RequestDomain
    {
        public string SearchHelper
        {
            get => $"{RequestNumber} {DepartureCity} {ArrivalCity} {ContainerSize} {CargoWeight} {Price} {DepartureDate} {RequestCreateDate} {Comment}";
        }
    }
}