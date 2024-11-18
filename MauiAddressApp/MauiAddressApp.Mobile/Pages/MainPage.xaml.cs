using MauiAddressApp.Mobile.Models;
using MauiAddressApp.Mobile.PageModels;

namespace MauiAddressApp.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}