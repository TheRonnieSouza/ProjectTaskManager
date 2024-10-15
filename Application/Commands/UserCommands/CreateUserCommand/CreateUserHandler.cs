using Application.Models;
using Application.Notification.UserCreated;
using Core.Repositories;
using MediatR;

namespace Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserHandler :IRequestHandler<CreateUserCommand, ResultViewModel<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        public CreateUserHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {            
            var newUser = request.ToEntity();

           var Id = _userRepository.Add(newUser);          

            var sendWelcomeEmailNotification = new UserCreatedNotification(
                newUser.Id, newUser.Email, newUser.Name);

            await _mediator.Publish(sendWelcomeEmailNotification);

            return ResultViewModel<Guid>.Success(newUser.Id);
        }
    }
}
