using Application.Models.Users.ViewModels;
using Application.Models;
using MediatR;

namespace Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UsersViewModels>>
    {
        public GetUserByIdQuery(Guid id) 
        {
            Id = id;
        }        
        public Guid Id { get; private set; }
    }
}
