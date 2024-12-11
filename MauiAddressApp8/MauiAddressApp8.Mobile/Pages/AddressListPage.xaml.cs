using MauiAddressApp8.Mobile.ViewModels;

namespace MauiAddressApp8.Mobile.Pages;

public partial class AddressListPage : ContentPage
{
	public AddressListPage(AddressListPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}