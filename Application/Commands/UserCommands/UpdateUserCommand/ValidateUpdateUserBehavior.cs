using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UserCommands.UpdateUserCommand
{
    public class ValidateUpdateUserBehavior : IPipelineBehavior<UpdateUserCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateUpdateUserBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {

            var userExist = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id && !u.IsDeleted);

            if (userExist != null)
                return ResultViewModel.Error("The user is not founded or deleted");

            if(!userExist.IsActive)
                return ResultViewModel.Error("The user is not active");

            return await next();
        }
    }
}
