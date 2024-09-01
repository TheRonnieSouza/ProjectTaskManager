using Domain.Entities.Users.InputModels;
using Domain.Entities.Users.ViewModels;
using Domain.TodoListDbContext;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly TodoListDbContext _context;
        public UserController(TodoListDbContext context)
        {
            _context = context;
        }
        //Delete api/users/1234
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var model = _context.Users.SingleOrDefault(u => u.Id == id);

            model.SetAsDeleted();
            //Remover um usuário específico do sistema.
            //Implementar uma lógica que previna a exclusão de usuários que ainda possuem tarefas pendentes ou em progresso (PLUS 2).
            return NoContent();
        }               

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.Where(u => u.IsActive).ToList();
            //fazer teste observando o valor de users com  _context.Users.Where(u => u.IsActive).ToList();
            //e                                            _context.Users.Select(u => u.IsActive).ToList();

            var usersViewModel = users.Select(UsersViewModels.FromEntity);   //new UsersViewModels();

            return Ok(usersViewModel);
        }

        //Get api/users?search=crm
        [HttpGet("search")]
        public IActionResult Get(string search)
        {
            //mecanismo de busca

            var user = _context.Users.SingleOrDefault(u => u.Email == search && u.IsActive == true);

            var userViewModel = UsersViewModels.FromEntity(user);

            return Ok();
        }

        //Get api/users/1234
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id && u.IsActive == true);

            var userViewModel = UsersViewModels.FromEntity(user);
            return Ok();
        }

        //Post api/users/
        [HttpPost]
        public IActionResult PostCreateUser(CreateUserInputModel model)
        {
            var newUser = model.ToEntity();

            _context.Users.Add(newUser);
            _context.SaveChanges();

            //Permitir o cadastro de novos usuários no sistema, validando informações como nome e email (PLUS 1).
            //Garantir que cada usuário possua um identificador único.
            //
            return CreatedAtAction(nameof(GetById), new { id = 12 }, model);
        }

        //Put api/users/1234
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id && u.IsActive == true).UpdateUser;
            //Permitir a atualização das informações de um usuário existente, como nome e email.
            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PutProfilePicture (IFormFile file)
        {
            var description = $"File : {file.FileName}, Size: {file.Length}";

            return Ok(description);
        }
    }

}
