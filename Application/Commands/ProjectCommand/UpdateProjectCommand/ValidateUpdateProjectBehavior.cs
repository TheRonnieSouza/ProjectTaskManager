using Application.Models;
using Core.Enums;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ProjectCommand.UpdateProjectCommand
{
    public class ValidateUpdateProjectBehavior :IPipelineBehavior<UpdateProjectCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ValidateUpdateProjectBehavior(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (project == null)
                return ResultViewModel.Error("Project not found.");

            var ProfileExist = _context.Users.Any(u => u.Id == request.ParticipatingId && u.Profile == Profile.Operator);

            if (!ProfileExist)
                return ResultViewModel.Error("The Operator to be up to date was not found.");

            ProfileExist = _context.Users.Any(u => u.Id == request.ParticipatingId && u.Profile == Profile.Manager);

            if (!ProfileExist)
                return ResultViewModel.Error("The Manager to be up to date was not found.");

            return await next();
        }
    }
}
