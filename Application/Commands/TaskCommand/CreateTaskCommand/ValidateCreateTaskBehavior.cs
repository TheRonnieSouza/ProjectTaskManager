using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.CreateTaskCommand
{
    public class ValidateCreateTaskBehavior : IPipelineBehavior<CreateTaskCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateCreateTaskBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateTaskCommand request, RequestHandlerDelegate<ResultViewModel<Guid>> next, CancellationToken cancellationToken)
        {
            var projectExist = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.ProjectId);

            if (projectExist == null)
                return ResultViewModel<Guid>.Error("The project for this task, does not exist.");

            var taskName = await _context.Tasks.AnyAsync(t => t.Title == request.Title && t.ProjectId == request.ProjectId);

            if (taskName)
                return ResultViewModel<Guid>.Error("The task already exist.");

            return await next();
        }
    }
}
