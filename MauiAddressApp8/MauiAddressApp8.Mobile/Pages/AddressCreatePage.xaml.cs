using MauiAddressApp8.Mobile.ViewModels;

namespace MauiAddressApp8.Mobile.Pages;

public partial class AddressCreatePage : ContentPage
{
    private AddressCreatePageViewModel _viewModel;
    public AddressCreatePage(AddressCreatePageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadData();
    }
    
}