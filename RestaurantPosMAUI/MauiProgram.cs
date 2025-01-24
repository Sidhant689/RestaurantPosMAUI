using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestaurantPosMAUI.Pages;
using RestaurantPosMAUI.Services;
using RestaurantPosMAUI.ViewModels;

namespace RestaurantPosMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}
