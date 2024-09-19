using Application.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.ProjectCommand.CreateProjectCommand
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public CreateProjectHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var newProject = request.ToEntity();
                
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();

            return ResultViewModel<Guid>.Success(newProject.Id);
        }
    }
}
