using MauiAddressApp8.Mobile.ViewModels;

namespace MauiAddressApp8.Mobile.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}