using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;


namespace MauiAddressApp8.Mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy = false;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !isBusy;

        public async Task ShowSuccessMessage(string message)
        {
            CancellationTokenSource tokenSource = new();

            SnackbarOptions options = new()
            {
                BackgroundColor = Colors.Green,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new(10)
            };

            ISnackbar snackBar = Snackbar.Make(message, duration: TimeSpan.FromSeconds(3), visualOptions: options);

            await snackBar.Show(tokenSource.Token);
        }

        public async Task ShowErrorMessage(string message)
        {
            CancellationTokenSource tokenSource = new();

            SnackbarOptions options = new()
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new(10)
            };

            ISnackbar snackBar = Snackbar.Make(message, duration: TimeSpan.FromSeconds(30), visualOptions: options);

            await snackBar.Show(tokenSource.Token);
        }

    }
}
