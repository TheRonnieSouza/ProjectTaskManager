using Application.Models;
using Application.Models.Projects.InputModels;
using Application.Models.Projects.ViewModels;
using Infrastructure.Persistence;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectTaskManagerDbContext _context;

        public ProjectService (ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<Guid> CreateProject(CreateProjectInputModel inputModel)
        {
            var newProject = inputModel.ToEntity(inputModel);

            _context.Projects.Add(newProject);
            _context.SaveChanges();

            return ResultViewModel<Guid>.Success(newProject.Id);               

        }

        public ResultViewModel<GetProjectViewModel> GetProjectById(Guid id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);

            if (project == null)
                return ResultViewModel<GetProjectViewModel>.Error("Nao foi encontrado nenhum projeto");
            
            var result = GetProjectViewModel.FromEntity(project);

            return ResultViewModel<GetProjectViewModel>.Success(result);
        }
    }
}
