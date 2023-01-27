using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PricesAndroid.Models
{
    public class Client : ClientDomain
    {
        public string FullName
        {
            get => $"{Name} {SurName} {Patronymic}";
        }
    }
}
