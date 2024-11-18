using CommunityToolkit.Mvvm.Input;
using MauiAddressApp.Mobile.Models;

namespace MauiAddressApp.Mobile.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}