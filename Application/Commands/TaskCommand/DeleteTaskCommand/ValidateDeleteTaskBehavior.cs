using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.DeleteTaskCommand
{
    public class ValidateDeleteTaskBehavior : IPipelineBehavior<DeleteTaskCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateDeleteTaskBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteTaskCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var task = _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id);

            if (task == null)
                return ResultViewModel.Error("Task not found.");

            if(!task.IsCompleted)
                return ResultViewModel.Error("Task needs to be finished.");

            return await next();
        }
    }
}
