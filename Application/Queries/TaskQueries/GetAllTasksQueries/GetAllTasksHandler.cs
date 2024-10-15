using Application.Models;
using Application.Models.Tasks.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, ResultViewModel<List<GetTaskViewModel>>>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTasksHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ResultViewModel<List<GetTaskViewModel>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAll();

            var model = tasks.Select(GetTaskViewModel.FromEntity).ToList();                     

            return ResultViewModel<List<GetTaskViewModel>>.Success(model);
        }
    }
}
