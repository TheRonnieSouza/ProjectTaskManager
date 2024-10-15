using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUserCommand
{
    public class ValidateDeleteBehavior : IPipelineBehavior<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public ValidateDeleteBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ExistActiveUser(request.Id);

            if (!user)
                return ResultViewModel.Error("The user is not active or is deleted!");

            return await next();
        }
    }
}
