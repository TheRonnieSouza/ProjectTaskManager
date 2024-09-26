using Application.Models;
using Core.Entites;
using MediatR;

namespace Application.Commands.ProjectCommand.CreateProjectCommand
{
    public class CreateProjectCommand :IRequest<ResultViewModel<Guid>>
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid ManagerId { get;  set; }

        public Project ToEntity()
                       => new(Id,Name, Description, ManagerId);

    }
}
