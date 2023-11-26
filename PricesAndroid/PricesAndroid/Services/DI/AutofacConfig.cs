using Autofac;
using PricesAndroid.Services.Interfaces;
using PricesAndroid.Services.TestServices;
using PricesAndroid.Utilities.RouteFactories;
using PricesAndroid.ViewModels;
using PricesAndroid.Views;

namespace PricesAndroid.Services.DI
{
    public class AutofacConfig
    {
        public static IContainer GetConfiguredContainer()
        {
            var url = "http://192.168.0.187:5181";

            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем споставление типов
            builder.RegisterType<App>().SingleInstance();
            builder.RegisterType<AppShell>().SingleInstance();

            builder.RegisterType<MainPageRouteFactory>();
            builder.RegisterType<RequestsPageRouteFactory>();
            builder.RegisterType<UserProfilePageRouteFactory>();

            builder.RegisterType<TestAuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<TestCitiesService>().As<ICitiesService>().SingleInstance();
            builder.RegisterType<TestRequestService>().As<IRequestService>().SingleInstance();
            builder.RegisterType<TestPriceDefiner>().As<IPriceDefiner>().SingleInstance();

            builder.RegisterType<MainPage>();
            builder.RegisterType<RequestsPage>();
            builder.RegisterType<SignInPage>();
            builder.RegisterType<UserProfilePage>();

            builder.RegisterType<MainViewModel>();
            builder.RegisterType<RequestsViewModel>();
            builder.RegisterType<SignInViewModel>();
            builder.RegisterType<UserProfileViewModel>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            return container;
        }
    }
}
