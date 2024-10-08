using Application.Models;
using Application.Notification.UserCreated;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserHandler :IRequestHandler<CreateUserCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        private readonly IMediator _mediator;
        public CreateUserHandler(ProjectTaskManagerDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {            
            var newUser = request.ToEntity();

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var sendWelcomeEmailNotification = new UserCreatedNotification(
                newUser.Id, newUser.Email, newUser.Name);

            await _mediator.Publish(sendWelcomeEmailNotification);

            return ResultViewModel<Guid>.Success(newUser.Id);
        }
    }
}
