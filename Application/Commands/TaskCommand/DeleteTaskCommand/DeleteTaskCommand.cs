using Application.Models;
using MediatR;

namespace Application.Commands.TaskCommand.DeleteTaskCommand
{
    public class DeleteTaskCommand : IRequest<ResultViewModel>
    {
        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

    }
}
