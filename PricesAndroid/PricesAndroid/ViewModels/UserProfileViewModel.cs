using System;
using System.Collections.Generic;
using System.Text;
using PricesAndroid.Models;

namespace PricesAndroid.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public User User { get; }

        public UserProfileViewModel()
        {
            User = new User();
        }
    }
}
