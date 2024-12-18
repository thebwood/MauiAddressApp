
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAddressApp8.ClassLibrary.Models;
using MauiAddressApp8.Mobile.Pages;
using MauiAddressApp8.Mobile.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Net;

namespace MauiAddressApp8.Mobile.ViewModels
{
    public partial class AddressListPageViewModel : BaseViewModel
    {
        private readonly IAddressClient _addressClient;
        public ObservableCollection<AddressModel> Addresses { get; } = new();

        public AddressListPageViewModel(IAddressClient addressClient)
        {
            _addressClient = addressClient;
        }

        public async Task LoadDataAsync()
        {
            if (Addresses.Count > 0)
            {
                Addresses.Clear();
            }

            var addresses = await _addressClient.GetAddresses();

            foreach (var address in addresses.AddressList)
            {
                var addressModel = new AddressModel
                {
                    Id = address.Id.Value,
                    StreetAddress = address.StreetAddress,
                    StreetAddress2 = address.StreetAddress2,
                    City = address.City,
                    State = address.State,
                    PostalCode = address.PostalCode
                };
                Addresses.Add(addressModel);
            }
        }
        [RelayCommand]
        public async Task CreateAddressAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddressCreatePage)}");
        }

        [RelayCommand]
        public async Task GoToDetailsAsync(AddressModel address)
        {
            await Shell.Current.GoToAsync($"{nameof(AddressDetailPage)}?addressId={address.Id}");
        }
    }
}
