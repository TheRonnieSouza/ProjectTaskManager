using Application.Models;
using Application.Models.Users.ViewModels;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsersQueries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UsersViewModels>>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public GetAllUsersHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<UsersViewModels>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Where(u => u.IsActive).ToList();

            if (users == null)
                return ResultViewModel<List<UsersViewModels>>.Error("O usuario nao foi encontrado");

            var usersViewModel = users.Select(UsersViewModels.FromEntity).ToList();

            return ResultViewModel<List<UsersViewModels>>.Success(usersViewModel);
        }
    }
}
