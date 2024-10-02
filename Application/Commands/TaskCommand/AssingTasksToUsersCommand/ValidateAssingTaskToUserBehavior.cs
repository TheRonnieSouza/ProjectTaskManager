using Application.Models;
using Core.Enums;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.AssingTasksToUsersCommand
{
    public class ValidateAssingTaskToUserBehavior : IPipelineBehavior<AssingTasksToUsersCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateAssingTaskToUserBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(AssingTasksToUsersCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == request.TaskId);

            if (task == null)
                return ResultViewModel.Error("Task not found.");

            var userExist = await _context.Users.AnyAsync(u => u.Id == request.UserId);

            if (!userExist)
                return ResultViewModel.Error("User not found.");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

            if(user.Profile != Profile.Operator)
                return ResultViewModel.Error("The user need to be a Operator.");

            return await next();
        }
    }
}
