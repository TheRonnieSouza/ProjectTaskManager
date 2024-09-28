using Application.Models;
using Application.Models.Projects.ViewModels;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.ProjectQueries.GetAllProjectQuery
{
    public class GetAllProjectHandler : IRequestHandler<GetAllProjectQuery, ResultViewModel<List<GetProjectViewModel>>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public GetAllProjectHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<GetProjectViewModel>>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var project = _context.Projects
                                   .Include(t => t.Tasks)
                                   .Include(m => m.Manager)
                                   .Where(p => !p.IsDeleted);//&& p.Manager.Id == p.ManagerId);

           
            var model = project.Select(GetProjectViewModel.FromEntity).ToList();

            return ResultViewModel<List<GetProjectViewModel>>.Success(model);
        }
    }
}
