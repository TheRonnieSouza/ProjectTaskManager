using Application.Models;
using Application.Models.Users.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsersQueries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UsersViewModels>>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<List<UsersViewModels>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            if (users == null)
                return ResultViewModel<List<UsersViewModels>>.Error("No users founded!");

            var usersViewModel = users.Select(UsersViewModels.FromEntity).ToList();

            return ResultViewModel<List<UsersViewModels>>.Success(usersViewModel);
        }
    }
}
