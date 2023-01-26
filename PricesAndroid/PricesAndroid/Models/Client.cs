using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PricesAndroid.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string INN { get; set; }

        private ObservableCollection<Request> requestsList;
        public ObservableCollection<Request> RequestsList
        {
            get
            {
                // подгружать из бд
                return requestsList = requestsList ?? new ObservableCollection<Request>();
            }
        }

        //public Client(int id = 0, string name = "Анастасия", string surName = "Челядникова", string patronymic = "Константиновна", string phoneNumber = "+7 (901) 453 45-15", string email = "nastya.chelyadnikova@mail.ru", string organization = "ООО \"Ромашка\"", string iNN = "519211514")
        //{
        //    Id = id;
        //    Name = name;
        //    SurName = surName;
        //    Patronymic = patronymic;
        //    PhoneNumber = phoneNumber;
        //    Email = email;
        //    Organization = organization;
        //    INN = iNN;

        //    FullName = $"{name} {surName} {patronymic}";
        //}
    }
}
