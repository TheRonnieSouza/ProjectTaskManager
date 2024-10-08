using Application.Models;
using Application.Notification.ProjectCreated;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.ProjectCommand.CreateProjectCommand
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        private readonly IMediator _mediator;
        public CreateProjectHandler(ProjectTaskManagerDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var newProject = request.ToEntity();
                
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();

            var projectCreatedNotification = new ProjectCreatedNotification(newProject.Id, newProject.ManagerId, newProject.Name);
            await _mediator.Publish(projectCreatedNotification);
            return ResultViewModel<Guid>.Success(newProject.Id);
        }
    }
}
