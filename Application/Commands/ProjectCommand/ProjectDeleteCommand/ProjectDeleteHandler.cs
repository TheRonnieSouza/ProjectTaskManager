using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ProjectCommand.ProjectDeleteCommand
{
    public class ProjectDeleteHandler : IRequestHandler<ProjectDeleteCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public ProjectDeleteHandler(ProjectTaskManagerDbContext context)
        { 
            _context = context;
        }
        public async Task<ResultViewModel> Handle(ProjectDeleteCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (project == null)
                 return  ResultViewModel.Error("Project not found!");

            project.SetAsDeleted();
            _context.Update(project);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();

        }
    }
}
