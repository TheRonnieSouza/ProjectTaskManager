using Application.Models;
using MediatR;

namespace Application.Commands.ProjectCommand.ProjectDeleteCommand
{
    public class ProjectDeleteCommand : IRequest<ResultViewModel>
    {
        public ProjectDeleteCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
