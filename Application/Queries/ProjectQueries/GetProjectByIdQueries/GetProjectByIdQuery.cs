using Application.Models;
using Application.Models.Projects.ViewModels;
using Core.Entites;
using MediatR;

namespace Application.Queries.ProjectQueries.GetProjectByIdQueries
{
    public class GetProjectByIdQuery : IRequest<ResultViewModel<GetProjectViewModel>>
    {
        public GetProjectByIdQuery(Guid id) 
        { 
            Id = id;
        }

        public Guid Id { get; set; }

        public static GetProjectViewModel FromEntity(Project entity)
               => new(entity.Name, entity.Description, entity.ManagerId,
                   entity.CreatedDate, entity.CompletedDate, entity.Tasks, entity.Participants);
    }
}
