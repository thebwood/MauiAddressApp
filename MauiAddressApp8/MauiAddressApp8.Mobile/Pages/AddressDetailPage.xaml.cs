using MauiAddressApp8.Mobile.ViewModels;
using System.Security.Cryptography;

namespace MauiAddressApp8.Mobile.Pages;

[QueryProperty(nameof(AddressId), "addressId")]
public partial class AddressDetailPage : ContentPage
{
    private AddressDetailPageViewModel _viewModel;
    public AddressDetailPage(AddressDetailPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    public string AddressId
    {
        set
        {
            _viewModel.LoadDataAsync(value);
        }
    }

}