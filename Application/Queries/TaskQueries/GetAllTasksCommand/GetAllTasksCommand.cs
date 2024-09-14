using Application.Models;
using Application.Models.Tasks.ViewModels;
using MediatR;

namespace Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksCommand : IRequest<ResultViewModel<List<GetTaskViewModel>>>
    {

    }
}
