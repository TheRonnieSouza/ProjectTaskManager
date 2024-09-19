using Application.Models;
using Application.Models.Tasks.ViewModels;
using MediatR;

namespace Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<ResultViewModel<List<GetTaskViewModel>>>
    {

    }
}
