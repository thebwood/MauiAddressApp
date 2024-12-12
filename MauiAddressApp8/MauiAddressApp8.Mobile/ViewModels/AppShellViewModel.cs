using CommunityToolkit.Mvvm.Input;
using MauiAddressApp8.Mobile.Pages;

namespace MauiAddressApp8.Mobile.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [RelayCommand]
        private async Task LogoutAsync()
        {
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
