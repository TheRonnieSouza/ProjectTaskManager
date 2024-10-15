using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.UpdateTaskCommand
{
    public class ValidateUpdateTaskBehavior : IPipelineBehavior<UpdateTaskCommand, ResultViewModel>
    {
        private readonly ITaskRepository _repository;

        public ValidateUpdateTaskBehavior(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateTaskCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var task = await _repository.GetById( request.Id);

            if (task == null)
                return ResultViewModel.Error("Task not found.");

            if (task.IsDeleted)
                return ResultViewModel.Error("Task was deleted.");

            if (task.Status == Core.Enums.EnumTaskStatus.Completed)
                return ResultViewModel.Error("Task already completed.");
            
            var taskValidateTitle = await _repository.TaskExistWithTheSameName(task);

            if (taskValidateTitle != null)
                return ResultViewModel.Error("Task with the same name already exist.");

            return await next();
        }
    }
}
