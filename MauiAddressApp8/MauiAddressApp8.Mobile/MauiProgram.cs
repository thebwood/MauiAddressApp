using MauiAddressApp8.Mobile.Services;
using MauiAddressApp8.Mobile.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Http;
namespace MauiAddressApp8.Mobile
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Set base address using platform-specific logic
            string baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                 ? "https://10.0.2.2:5001" // Android emulator
                 : "https://localhost:5001"; // iOS simulator
                                             // Define the retry policy
                                             // Define the retry policy
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError() // Handles 5xx and 408 errors
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

            // Add HttpClient with retry policy
            builder.Services.AddHttpClient<IAddressClient, AddressClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            })
            .AddPolicyHandler(retryPolicy); // Attach the retry policy

            return builder.Build();
        }

    }
}
