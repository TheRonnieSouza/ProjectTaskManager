using Application.Models;
using Application.Models.Projects.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.ProjectQueries.GetProjectByIdQueries
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<GetProjectViewModel>>
    {
        private readonly IProjectRepository _repository;
        public GetProjectByIdHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<GetProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetDatailsById(request.Id);

            var result = GetProjectViewModel.FromEntity(project);

            return ResultViewModel<GetProjectViewModel>.Success(result);
        }
    }
}
