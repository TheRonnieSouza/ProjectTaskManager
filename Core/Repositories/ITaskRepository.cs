using Core.Entites;

namespace Core.Repositories
{
    public interface ITaskRepository
    {
        Task<List<tTask>> GetAll();
        Task<tTask> GetDatailsById(Guid id);
        Task<tTask> GetById(Guid id);
        Task<bool> Exist(Guid id);
        Task<bool> TaskExistWithTheSameName(tTask task);
        Task<Guid> Add(tTask project);
        Task Update(tTask project);
    }
}
