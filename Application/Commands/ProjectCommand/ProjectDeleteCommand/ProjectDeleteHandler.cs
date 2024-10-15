using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.ProjectCommand.ProjectDeleteCommand
{
    public class ProjectDeleteHandler : IRequestHandler<ProjectDeleteCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public ProjectDeleteHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(ProjectDeleteCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            project.SetAsDeleted();
            _repository.Update(project);

            return ResultViewModel.Success();

        }
    }
}
