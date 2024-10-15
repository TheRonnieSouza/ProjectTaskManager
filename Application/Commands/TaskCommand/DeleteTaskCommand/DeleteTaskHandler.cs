using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.DeleteTaskCommand
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, ResultViewModel>
    {
        private readonly ITaskRepository _repository;

        public DeleteTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetById(request.Id);
             
            task.SetAsDeleted();
            _repository.Update(task);
            return ResultViewModel.Success();
        }
    }
}
