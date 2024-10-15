using Core.Entites;

namespace Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> GetDatailsById(Guid id);
        Task<Project> GetById(Guid id);
        Task<bool> Exist(Guid id);
        Task<Guid> Add(Project project);
        Task Update(Project project);
    }   
}
