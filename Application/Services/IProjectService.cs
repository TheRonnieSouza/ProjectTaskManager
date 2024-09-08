using Application.Models;
using Application.Models.Projects.InputModels;
using Application.Models.Projects.ViewModels;

namespace Application.Services
{
    public interface IProjectService
    {
        public ResultViewModel<Guid> CreateProject(CreateProjectInputModel inputModel);

        public ResultViewModel<GetProjectViewModel> GetProjectById (Guid id);
    }
}
