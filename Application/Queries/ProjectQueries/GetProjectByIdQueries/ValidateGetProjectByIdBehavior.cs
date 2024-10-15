using Application.Models.Projects.ViewModels;
using Application.Models;
using MediatR;
using Core.Repositories;

namespace Application.Queries.ProjectQueries.GetProjectByIdQueries
{
    public class ValidateGetProjectByIdBehavior : IPipelineBehavior<GetProjectByIdQuery, ResultViewModel<GetProjectViewModel>>
    {
        private readonly IProjectRepository _repository;
        public ValidateGetProjectByIdBehavior(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<GetProjectViewModel>> Handle(GetProjectByIdQuery request, RequestHandlerDelegate<ResultViewModel<GetProjectViewModel>> next, CancellationToken cancellationToken)
        {
            var project = await _repository.Exist(request.Id);

            if (!project)
                return ResultViewModel<GetProjectViewModel>.Error("There not found the any projects.");

            return await next();
        }
    }
 
}
