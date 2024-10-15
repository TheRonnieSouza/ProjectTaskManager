using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.ProjectCommand.UpdateProjectCommand
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public UpdateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            project.UpdateProject(request.Description, request.CompletedDate,request.ManagerId,request.ParticipatingId);
            _repository.Update(project);

            return ResultViewModel.Success();
        }
    }
}
