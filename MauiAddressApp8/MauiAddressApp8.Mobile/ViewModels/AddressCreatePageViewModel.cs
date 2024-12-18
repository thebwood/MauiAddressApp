using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAddressApp8.ClassLibrary.Models;
using MauiAddressApp8.Mobile.Pages;
using MauiAddressApp8.Mobile.Services.Interfaces;
using System.Net;

namespace MauiAddressApp8.Mobile.ViewModels
{
    public partial class AddressCreatePageViewModel : BaseViewModel
    {
        private readonly IAddressClient _addressClient;

        [ObservableProperty]
        private AddressModel address = new();

        public AddressCreatePageViewModel(IAddressClient addressClient)
        {
            _addressClient = addressClient;
        }
        public void LoadData()
        {
            Address = new AddressModel();
        }

        [RelayCommand]
        public async Task SaveAddressAsync()
        {
            try
            {
                ResultModel result;

                IsBusy = true;

                result = await _addressClient.CreateAddress(Address);

                if (result == null || !result.Success)
                {
                    await ShowErrorMessage("Failed to save address.");
                }
                else if (result.Success)
                {
                    await ShowSuccessMessage("Address saved successfully.");
                    await Shell.Current.GoToAsync($"//{nameof(AddressListPage)}");
                }

            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
