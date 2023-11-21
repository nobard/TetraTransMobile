using PricesAndroid.ViewModels;
using PricesAndroid.Views;
using Xamarin.Forms;

namespace PricesAndroid.Utilities.RouteFactories
{
    public class UserProfilePageRouteFactory : RouteFactory
    {
        private readonly UserProfileViewModel viewModel;

        public UserProfilePageRouteFactory(UserProfileViewModel vm)
        {
            viewModel = vm;
        }

        public override Element GetOrCreate()
        {
            var elem = new UserProfilePage(viewModel);

            return elem;
        }
    }
}
