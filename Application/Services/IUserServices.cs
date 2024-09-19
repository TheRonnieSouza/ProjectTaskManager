using Application.Models;
using Application.Models.Users.InputModels;
using Application.Models.Users.ViewModels;

namespace Application.Services
{
    public interface IUserService
    {
        public ResultViewModel DeleteUser(Guid id);
        public ResultViewModel<List<UsersViewModels>> GetSearch(string search);
        public ResultViewModel<List<UsersViewModels>> GetAllUsers();
        public ResultViewModel<UsersViewModels> GetUserById(Guid id);
        public ResultViewModel<Guid> CreateUser(CreateUserInputModel inputModel);
        public ResultViewModel UpdateUser(Guid id, UpdateUserInputModel inputModel);
        
    }
}
