using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.ProjectCommand.ProjectDeleteCommand
{
    public class ValidateProjectDeleteBehavior :IPipelineBehavior<ProjectDeleteCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public ValidateProjectDeleteBehavior(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(ProjectDeleteCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

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
