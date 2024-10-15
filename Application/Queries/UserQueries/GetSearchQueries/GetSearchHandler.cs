using Application.Models;
using Application.Models.Users.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.UserQueries.GetSearchQueries
{
    public class GetSearchHandler : IRequestHandler<GetSearchQuery, ResultViewModel<List<UsersViewModels>>>
    {
        private readonly IUserRepository _userRepository;
        public GetSearchHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel<List<UsersViewModels>>> Handle(GetSearchQuery request, CancellationToken cancellationToken)
        {
            //TODO 
            //mecanismo de busca

            var user = await _userRepository.GetAllSearch(request.Search);

            if (user == null)
                return ResultViewModel<List<UsersViewModels>>.Error("No user founded.");

            var usersViewModel =  user.Select(UsersViewModels.FromEntity).ToList();

            return ResultViewModel<List<UsersViewModels>>.Success(usersViewModel);
        }
    }
}
