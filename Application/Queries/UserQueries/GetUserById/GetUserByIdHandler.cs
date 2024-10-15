using Application.Models;
using Application.Models.Users.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UsersViewModels>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<UsersViewModels>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            var userViewModel = UsersViewModels.FromEntity(user);

            return ResultViewModel<UsersViewModels>.Success(userViewModel);
        }
    }
}
