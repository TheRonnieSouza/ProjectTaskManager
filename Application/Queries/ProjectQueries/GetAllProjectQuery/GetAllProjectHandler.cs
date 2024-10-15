using Application.Models;
using Application.Models.Projects.ViewModels;
using Core.Repositories;
using MediatR;

namespace Application.Queries.ProjectQueries.GetAllProjectQuery
{
    public class GetAllProjectHandler : IRequestHandler<GetAllProjectQuery, ResultViewModel<List<GetProjectViewModel>>>
    {
        private readonly IProjectRepository _repository;
        public GetAllProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<GetProjectViewModel>>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetAll();

            var model = project.Select(GetProjectViewModel.FromEntity).ToList();

            return ResultViewModel<List<GetProjectViewModel>>.Success(model);
        }
    }
}
