using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.DeleteTaskCommand
{
    public class ValidateDeleteTaskBehavior : IPipelineBehavior<DeleteTaskCommand, ResultViewModel>
    {
        private readonly ITaskRepository _taskRepository;

        public ValidateDeleteTaskBehavior(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteTaskCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.Id);

            if (task == null)
                return ResultViewModel.Error("Task not found.");

            return await next();
        }
    }
}
