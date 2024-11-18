using MauiAddressApp8.Mobile.ViewModels;

namespace MauiAddressApp8.Mobile.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel model)
	{
		InitializeComponent();
        BindingContext = model;
    }
}