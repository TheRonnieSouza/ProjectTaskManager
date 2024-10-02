using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.UpdateTaskCommand
{
    public class ValidateUpdateTaskBehavior : IPipelineBehavior<UpdateTaskCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateUpdateTaskBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateTaskCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id);

            if (task == null)
                return ResultViewModel.Error("Task not found.");

            if (task.IsDeleted)
                return ResultViewModel.Error("Task was deleted.");

            if (task.IsCompleted)
                return ResultViewModel.Error("Task already completed.");
            
            var taskValidateTitle = await _context.Tasks.FirstOrDefaultAsync(t =>  t.Title == request.Title && t.ProjectId == request.ProjectId);

            if (taskValidateTitle != null)
                return ResultViewModel.Error("Task with the same name already exist.");

            return await next();
        }
    }
}
