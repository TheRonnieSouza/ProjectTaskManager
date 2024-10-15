using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.UpdateTaskCommand
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, ResultViewModel>
    {
        private readonly ITaskRepository _repository;

        public UpdateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetById(request.Id);
            task.UpdateTask(request.Title,request.Description, request.Priority,request.DeliveryDate,request.UserId, request.ProjectId);
            _repository.Update(task);

            return ResultViewModel.Success();
        }
    }
}
