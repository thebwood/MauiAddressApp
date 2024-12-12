using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAddressApp8.Mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;
    }
}
