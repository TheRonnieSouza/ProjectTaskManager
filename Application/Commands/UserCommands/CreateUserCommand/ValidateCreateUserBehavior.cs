using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.UserCommands.CreateUserCommand
{
    public class ValidateCreateUserBehavior : IPipelineBehavior<CreateUserCommand, ResultViewModel<Guid>>
    {
        private readonly IUserRepository _userRepository;

        public ValidateCreateUserBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, RequestHandlerDelegate<ResultViewModel<Guid>> next, CancellationToken cancellationToken)
        {
            bool emailExist = await _userRepository.ExistEmail(request.Email);

            if (emailExist)
                return ResultViewModel<Guid>.Error($"Alredy exist the email: {request.Email}");

            return await next();
        }
    }
}
