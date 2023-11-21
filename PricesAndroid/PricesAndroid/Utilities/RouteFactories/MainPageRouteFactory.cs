using PricesAndroid.ViewModels;
using PricesAndroid.Views;
using Xamarin.Forms;

namespace PricesAndroid.Utilities.RouteFactories
{
    public class MainPageRouteFactory : RouteFactory
    {
        private readonly MainViewModel viewModel;

        public MainPageRouteFactory(MainViewModel vm)
        {
            viewModel = vm;
        }

        public override Element GetOrCreate()
        {
            var elem = new MainPage(viewModel);

            return elem;
        }
    }
}
