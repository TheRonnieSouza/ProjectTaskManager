using Application.Models;
using Application.Notification.ProjectCreated;
using Core.Repositories;
using MediatR;

namespace Application.Commands.ProjectCommand.CreateProjectCommand
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ResultViewModel<Guid>>
    {
        private readonly IProjectRepository _repository;
        private readonly IMediator _mediator;
        public CreateProjectHandler(IProjectRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public async Task<ResultViewModel<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var newProject = request.ToEntity();

            _repository.Add(newProject);
            var projectCreatedNotification = new ProjectCreatedNotification(newProject.Id, newProject.ManagerId, newProject.Name);
            await _mediator.Publish(projectCreatedNotification);
            return ResultViewModel<Guid>.Success(newProject.Id);
        }
    }
}
