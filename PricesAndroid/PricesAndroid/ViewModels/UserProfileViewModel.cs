using System;
using System.Collections.Generic;
using System.Text;
using PricesAndroid.Models;

namespace PricesAndroid.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public Client User { get; }

        public UserProfileViewModel()
        {
            User = App.Client;
        }
    }
}
