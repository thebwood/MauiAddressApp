using MauiAddressApp8.Mobile.ViewModels;

namespace MauiAddressApp8.Mobile.Pages;

public partial class AddressListPage : ContentPage
{
    private readonly AddressListPageViewModel _viewModel;

    public AddressListPage(AddressListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataAsync();
    }


}