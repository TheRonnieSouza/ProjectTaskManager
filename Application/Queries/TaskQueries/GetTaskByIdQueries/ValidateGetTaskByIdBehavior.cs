using Application.Models.Tasks.ViewModels;
using Application.Models;
using MediatR;
using Core.Repositories;

namespace Application.Queries.TaskQueries.GetTaskById
{
    public class ValidateGetTaskByIdBehavior : IPipelineBehavior<GetTaskByIdQuery, ResultViewModel<GetTaskViewModel>>
    {
        private readonly ITaskRepository _taskRepository;
        public ValidateGetTaskByIdBehavior(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        
        public async Task<ResultViewModel<GetTaskViewModel>> Handle(GetTaskByIdQuery request, RequestHandlerDelegate<ResultViewModel<GetTaskViewModel>> next, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.Exist(request.Id);

            if (task == null)          
                return ResultViewModel<GetTaskViewModel>.Error("Task not founded!");

            return await next();
        }
    }
}
