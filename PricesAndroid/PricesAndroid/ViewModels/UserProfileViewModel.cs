using System;
using System.Collections.Generic;
using System.Text;
using PricesAndroid.Models;

namespace PricesAndroid.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        private Client user;

        public UserProfileViewModel(Client user)
        {
            this.user = user;
        }
    }
}
