using PricesAndroid.Models;

namespace PricesAndroid.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        private UserInfo user;

        public UserProfileViewModel()
        {
            App.UserChanged += OnUserChanged;
        }

        private void OnUserChanged(UserChangedEventArgs args)
        {
            user = args.NewUserInfo;
        }
    }
}
