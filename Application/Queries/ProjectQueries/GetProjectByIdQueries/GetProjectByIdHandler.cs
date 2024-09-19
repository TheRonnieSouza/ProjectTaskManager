using Application.Models.Projects.ViewModels;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Application.Queries.ProjectQueries.GetProjectByIdQueries
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<GetProjectViewModel>>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public GetProjectByIdHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<GetProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null)
                return ResultViewModel<GetProjectViewModel>.Error("Nao foi encontrado nenhum projeto");

            var result = GetProjectViewModel.FromEntity(project);

            return ResultViewModel<GetProjectViewModel>.Success(result);
        }
    }
}
