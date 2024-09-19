using Application.Models;
using Core.Entites;
using MediatR;

namespace Application.Commands.ProjectCommand.CreateProjectCommand
{
    public class CreateProjectCommand :IRequest<ResultViewModel<Guid>>
    {
        
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public Guid ManagerId { get; private set; }

        public Project ToEntity()
                       => new(Name, Description, ManagerId);

    }
}
