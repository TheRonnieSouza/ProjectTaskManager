using Application.Models;
using Application.Models.Tasks.InputModel;
using Application.Models.Tasks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITaskService
    {
        ResultViewModel DeleteTask(Guid id);

        ResultViewModel<List<GetTaskViewModel>> GetAllTasks();

        ResultViewModel<GetTaskViewModel> GetTaskById(Guid id);

        ResultViewModel<Guid> PostCreateTask(CreateTaskInputModel inputModel);

        ResultViewModel UpdateTask(Guid id, UpdateTaskInputModel inputModel);

        ResultViewModel AssingTasksToUsers(Guid id,Guid idUser);
    }
}
