using System.Collections.Generic;

namespace PricesAndroid.Models
{
    public class Client
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

        //проверить, будет ли ошибка NullRefEx -- да, будет
        public IEnumerable<Request> Requests { get; set; }

        public string FullName 
            => $"{Name} {SurName} {Patronymic}";
    }
}
