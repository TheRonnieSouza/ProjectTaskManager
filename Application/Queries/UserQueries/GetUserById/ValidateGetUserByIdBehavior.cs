using Application.Models.Users.ViewModels;
using Application.Models;
using MediatR;
using Core.Repositories;

namespace Application.Queries.UserQueries.GetUserById
{
    public class ValidateGetUserByIdBehavior : IPipelineBehavior<GetUserByIdQuery, ResultViewModel<UsersViewModels>>
    {
        private readonly IUserRepository _userRepository;
        public ValidateGetUserByIdBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async  Task<ResultViewModel<UsersViewModels>> Handle(GetUserByIdQuery request, RequestHandlerDelegate<ResultViewModel<UsersViewModels>> next, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Exist(request.Id);

            if (!user)
                return ResultViewModel<UsersViewModels>.Error("User not founded!");
                    
            return await next();
        }
    }
}
