using Application.Models;
using Application.Models.Tasks.ViewModels;
using Application.Models.Users.InputModels;
using Application.Models.Users.ViewModels;
using Core.Entites;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserServices : IUserService
    {
        private readonly ProjectTaskManagerDbContext _context;

        public UserServices(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public ResultViewModel DeleteUser(Guid id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return ResultViewModel.Error("O usuario nao pode ser deletado ou nao fo encontrado");

            user.SetAsDeleted();
            _context.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<UsersViewModels>> Get(string search)
        {
            //TODO 
            //mecanismo de busca

            var user = _context.Users.Where(u => u.Email == search && u.IsActive == true);

            if (user == null)
                return ResultViewModel<List<UsersViewModels>>.Error("O usuario nao foi encontrado");

            var usersViewModel = user.Select(UsersViewModels.FromEntity).ToList();

            return ResultViewModel<List<UsersViewModels>>.Success(usersViewModel);
        }

        public ResultViewModel<List<UsersViewModels>> GetAllUsers()
        {
            //TODO
            //fazer teste observando o valor de users com  _context.Users.Where(u => u.IsActive).ToList();
            //e                                            _context.Users.Select(u => u.IsActive).ToList();

            var users = _context.Users.Where(u => u.IsActive).ToList();

            if (users == null)
                return ResultViewModel<List<UsersViewModels>>.Error("O usuario nao foi encontrado");

            var usersViewModel = users.Select(UsersViewModels.FromEntity).ToList();

            return ResultViewModel<List<UsersViewModels>>.Success(usersViewModel);
        }

        public ResultViewModel<UsersViewModels> GetUserById(Guid id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id && u.IsActive == true);

            if (user == null)
               return ResultViewModel<UsersViewModels>.Error("Usuario nao encotrado");

            var userViewModel = UsersViewModels.FromEntity(user);

            return ResultViewModel<UsersViewModels>.Success(userViewModel);
        }

        public ResultViewModel<Guid> PostCreateUser(CreateUserInputModel inputModel)
        {
            //TODO 
            //Permitir o cadastro de novos usuários no sistema, validando informações como nome e email (PLUS 1).
            //Garantir que cada usuário possua um identificador único.
            //
            var newUser = inputModel.ToEntity();

            _context.Users.Add(newUser);
            _context.SaveChanges();
           
            return ResultViewModel<Guid>.Success(newUser.Id);
        }

        public ResultViewModel UpdateUser(Guid id, UpdateUserInputModel inputModel)
        {
            //TODO
            //Atualizar metodo atualizando o usuario
            throw new NotImplementedException();
        }
    }
}
