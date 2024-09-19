using Application.Models;
using Application.Models.Users.ViewModels;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsersQueries
{
    public class GetAllUsersQuery : IRequest<ResultViewModel<List<UsersViewModels>>>
    {
    }
}
