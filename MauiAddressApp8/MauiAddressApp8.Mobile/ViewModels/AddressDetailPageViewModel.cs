using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAddressApp8.ClassLibrary.Dtos;
using MauiAddressApp8.ClassLibrary.Models;
using MauiAddressApp8.Mobile.Pages;
using MauiAddressApp8.Mobile.Services.Interfaces;
using System.Net;

namespace MauiAddressApp8.Mobile.ViewModels
{
    public partial class AddressDetailPageViewModel : BaseViewModel
    {
        private readonly IAddressClient _addressClient;

        [ObservableProperty]
        private AddressModel address = new();

        public AddressDetailPageViewModel(IAddressClient addressClient)
        {
            _addressClient = addressClient;
        }

        public async Task LoadDataAsync(string id)
        {
            GetAddressResponseDTO? responseDTO = await _addressClient.GetAddress(Guid.Parse(id));
            Address = new AddressModel
            {
                Id = responseDTO.Address.Id.Value,
                StreetAddress = responseDTO.Address.StreetAddress,
                City = responseDTO.Address.City,
                State = responseDTO.Address.State,
                PostalCode = responseDTO.Address.PostalCode
            };
        }

        [RelayCommand]
        public async Task SaveAddressAsync()
        {
            try
            {
                ResultModel result;

                IsBusy = true;

                result = await _addressClient.UpdateAddress(Address);

                if (result == null || !result.Success)
                {
                    await ShowErrorMessage("Failed to save address.");
                }
                else if(result.Success)
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
