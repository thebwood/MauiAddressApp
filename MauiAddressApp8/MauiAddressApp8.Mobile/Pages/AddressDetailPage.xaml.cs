using MauiAddressApp8.Mobile.ViewModels;

namespace MauiAddressApp8.Mobile.Pages;

public partial class AddressDetailPage : ContentPage
{
	public AddressDetailPage(AddressDetailPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}