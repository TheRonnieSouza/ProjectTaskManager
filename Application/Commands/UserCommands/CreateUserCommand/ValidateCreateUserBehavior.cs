using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UserCommands.CreateUserCommand
{
    public class ValidateCreateUserBehavior : IPipelineBehavior<CreateUserCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateCreateUserBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, RequestHandlerDelegate<ResultViewModel<Guid>> next, CancellationToken cancellationToken)
        {
            bool emailExist = await _context.Users.AnyAsync(u =>  u.Email == request.Email);

            if (emailExist)
                return ResultViewModel<Guid>.Error($"Alredy exist the email: {request.Email}");

            return await next();
        }
    }
}
