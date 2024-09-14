using Application.Models;
using Application.Models.Tasks.InputModel;
using Application.Models.Tasks.ViewModels;

namespace Application.Services
{
    public interface ITaskService
    {
        ResultViewModel DeleteTask(Guid id);

        ResultViewModel<List<GetTaskViewModel>> GetAllTasks();

        ResultViewModel<GetTaskViewModel> GetTaskById(Guid id);

        ResultViewModel<Guid> CreateTask(CreateTaskInputModel inputModel);

        ResultViewModel UpdateTask(UpdateTaskInputModel inputModel);

        ResultViewModel AssingTasksToUsers(Guid id,Guid idUser);
    }
}
