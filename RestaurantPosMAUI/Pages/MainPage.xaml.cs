using RestaurantPosMAUI.ViewModels;

namespace RestaurantPosMAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();
           
        }

       
    }

}
