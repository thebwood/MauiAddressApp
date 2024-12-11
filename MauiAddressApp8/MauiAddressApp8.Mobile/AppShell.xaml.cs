using MauiAddressApp8.Mobile.Pages;
using MauiAddressApp8.Mobile.ViewModels;

namespace MauiAddressApp8.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(AddressDetailPage), typeof(AddressDetailPage));
        }
    }
}
