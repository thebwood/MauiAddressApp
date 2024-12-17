using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAddreessApp8.ClassLibrary.Dtos;
using MauiAddreessApp8.ClassLibrary.Models;
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
            if(id == "new")
            {
                Address = new AddressModel();
            }
            else
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
        }

        [RelayCommand]
        public async Task SaveAddressAsync()
        {
            try
            {
                ResultModel result;

                IsBusy = true;

                result = await _addressClient.UpdateAddress(Address);

                if(result == null || result.StatusCode != HttpStatusCode.OK)
                {
                    await ShowErrorMessage("Failed to save address.");
                }
                else if(result.StatusCode == HttpStatusCode.OK)
                {
                    await ShowSuccessMessage("Address saved successfully.");
                    await Shell.Current.GoToAsync("//addresslistpage");
                }

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
