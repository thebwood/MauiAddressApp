using CommunityToolkit.Mvvm.ComponentModel;
using MauiAddreessApp8.ClassLibrary.Models;
using System.Collections.ObjectModel;

namespace MauiAddressApp8.Mobile.ViewModels
{
    public partial class AddressDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private AddressModel _addresses = new();

        public AddressDetailPageViewModel()
        {
        }
    }
}
