using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.AssingTasksToUsersCommand
{
    public class AssingTasksToUsersHandler : IRequestHandler<AssingTasksToUsersCommand, ResultViewModel>     
    {
        private readonly ITaskRepository _repository;

        public AssingTasksToUsersHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(AssingTasksToUsersCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetById(request.TaskId);

            task.AssingTasksToUser(request.UserId);

           _repository.Update(task);

            return ResultViewModel.Success();
        }
    }
}
