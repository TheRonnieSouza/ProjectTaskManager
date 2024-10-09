using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UserCommands.DeleteUserCommand
{
    public class ValidateDeleteBehavior : IPipelineBehavior<DeleteUserCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateDeleteBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var userDeleted = await _context.Users.AnyAsync(u => u.Id == request.Id && u.IsActive && !u.IsDeleted);

            if (!userDeleted)
                return ResultViewModel.Error("The user is not active or is deleted!");

            return await next();
        }
    }
}
