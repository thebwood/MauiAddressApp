using MauiAddressApp8.Mobile.Services;
using MauiAddressApp8.Mobile.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Http;
using MauiAddressApp8.Mobile.ViewModels;
using MauiAddressApp8.Mobile.Pages;
using CommunityToolkit.Maui;
namespace MauiAddressApp8.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Set base address using platform-specific logic
            string baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                 ? "http://10.0.2.2:5025" // Android emulator
                 : "http://localhost:5025"; // iOS simulator
                                             // Define the retry policy
                                             // Define the retry policy
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError() // Handles 5xx and 408 errors
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

            // Add HttpClient with retry policy
            builder.Services.AddHttpClient<IAddressClient, AddressClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            });


            // Register Views (Pages)
            builder.Services.AddSingleton<AddressCreatePage>();
            builder.Services.AddSingleton<AddressDetailPage>();
            builder.Services.AddSingleton<AddressListPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoginPage>();

            // Register ViewModels
            builder.Services.AddTransient<AddressCreatePageViewModel>();
            builder.Services.AddTransient<AddressDetailPageViewModel>();
            builder.Services.AddTransient<AddressListPageViewModel>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<LoginPageViewModel>();
            
            return builder.Build();
        }

    }
}
