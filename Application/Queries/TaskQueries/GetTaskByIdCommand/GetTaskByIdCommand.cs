using Application.Models;
using Application.Models.Tasks.ViewModels;
using MediatR;

namespace Application.Queries.TaskQueries.GetTaskById
{
    public class GetTaskByIdCommand : IRequest<ResultViewModel<GetTaskViewModel>>
    {
        public GetTaskByIdCommand(Guid id) 
        {
            Id = id;        
        }
        public Guid Id { get; private set ; }
    }
}
