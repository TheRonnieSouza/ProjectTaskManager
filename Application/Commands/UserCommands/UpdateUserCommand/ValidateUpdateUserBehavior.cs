using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUserCommand
{
    public class ValidateUpdateUserBehavior : IPipelineBehavior<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public ValidateUpdateUserBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {

            var userExist = await _userRepository.GetById(request.Id);

            if (userExist != null)
                return ResultViewModel.Error("The user is not founded or deleted");

            if(!userExist.IsActive)
                return ResultViewModel.Error("The user is not active");

            return await next();
        }
    }
}
