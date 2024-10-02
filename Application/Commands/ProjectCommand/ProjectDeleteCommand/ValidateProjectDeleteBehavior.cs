using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ProjectCommand.ProjectDeleteCommand
{
    public class ValidateProjectDeleteBehavior :IPipelineBehavior<ProjectDeleteCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateProjectDeleteBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(ProjectDeleteCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (project.IsDeleted)
                return ResultViewModel.Error("Project already deleted.");            

            if (project == null)
                return ResultViewModel.Error("Project not found.");
           
            if (project.CompletedDate == null)
                return ResultViewModel.Error("The project need to be completed to delete.");

            return await next();
        }
    }
}
