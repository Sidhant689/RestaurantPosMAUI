using RestaurantPosMAUI.ViewModels;

namespace RestaurantPosMAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly HomeViewModel _homeViewModel;
        public MainPage(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            _homeViewModel = homeViewModel;
            BindingContext = _homeViewModel;
            Initialize();

            //BindingContext = new HomeViewModel();
        }

        private async void Initialize()
        {
            _homeViewModel.InitializeAsync();
        }


    }

}
