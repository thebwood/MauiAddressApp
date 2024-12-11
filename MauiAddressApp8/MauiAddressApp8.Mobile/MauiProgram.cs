using MauiAddressApp8.Mobile.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Devices;

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

            // Register HttpClient with base address
            builder.Services.AddHttpClient<IAddressService>("AddressClient", client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
            });

            return builder.Build();
        }
    }
}
