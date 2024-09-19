using Application.Models;
using Application.Models.Tasks.ViewModels;
using MediatR;

namespace Application.Queries.TaskQueries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<ResultViewModel<GetTaskViewModel>>
    {
        public GetTaskByIdQuery(Guid id) 
        {
            Id = id;        
        }
        public Guid Id { get; private set ; }
    }
}
