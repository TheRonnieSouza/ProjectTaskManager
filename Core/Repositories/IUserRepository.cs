using Core.Entites;
using Core.Enums;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> Add(User user);
        Task Update(User user);
        Task<User> GetDetailsById(Guid id);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<bool> Exist(Guid id);
        Task<bool> ExistEmail(string email);
        Task<bool> ExistActiveUser(Guid id);
        Task<bool> ProfileExist(Guid id, Profile profile);
        Task<List<User>> GetAllSearch(string email);
    }
}
