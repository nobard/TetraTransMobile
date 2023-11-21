using PricesAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PricesAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        private readonly UserProfileViewModel viewModel;

        public UserProfilePage(UserProfileViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}