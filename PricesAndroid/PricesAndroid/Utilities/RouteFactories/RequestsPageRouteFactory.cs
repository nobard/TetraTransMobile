using PricesAndroid.ViewModels;
using PricesAndroid.Views;
using Xamarin.Forms;

namespace PricesAndroid.Utilities.RouteFactories
{
    public class RequestsPageRouteFactory : RouteFactory
    {
        private readonly RequestsViewModel viewModel;

        public RequestsPageRouteFactory(RequestsViewModel vm)
        {
            viewModel = vm;
        }

        public override Element GetOrCreate()
        {
            var elem = new RequestsPage(viewModel);

            return elem;
        }
    }
}
