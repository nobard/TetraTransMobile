using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PricesAndroid.Models
{
    public class ClientDomain
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Patronymic { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string INN { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public ObservableCollection<Request> Requests { get; set; } = new ObservableCollection<Request>();
    }
}
