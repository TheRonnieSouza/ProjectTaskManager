using Application.Models;
using Application.Models.Tasks.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.TaskQueries.GetTaskById
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, ResultViewModel<GetTaskViewModel>>
    {
        private readonly ITaskRepository _taskRepository;
        public GetTaskByIdHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ResultViewModel<GetTaskViewModel>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.Id);
           
            var model = GetTaskViewModel.FromEntity(task);

            return ResultViewModel<GetTaskViewModel>.Success(model);
        }
    }
}
