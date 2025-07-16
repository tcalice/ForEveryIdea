using CommunityToolkit.Mvvm.Input;
using ModelAppForEveryIdea.Models;

namespace ModelAppForEveryIdea.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}