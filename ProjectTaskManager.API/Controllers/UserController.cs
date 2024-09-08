using Application.Models.Users.InputModels;
using Application.Models.Users.ViewModels;
using Application.Services;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        //Delete api/users/1234
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var result = _service.DeleteUser(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }               

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _service.GetAllUsers();

            return Ok(result);
        }

        //Get api/users?search=crm
        [HttpGet("search")]
        public IActionResult Get(string search)
        {
            var result = _service.Get(search);

            return Ok(result);
        }

        //Get api/users/1234
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var result = _service.GetUserById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //Post api/users/
        [HttpPost]
        public IActionResult PostCreateUser(CreateUserInputModel inputModel)
        {
            var result = _service.PostCreateUser(inputModel);

            return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, inputModel);
        }

        //Put api/users/1234
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, UpdateUserInputModel inputModel)
        {
            var result = _service.UpdateUser(id, inputModel);

            if (result == null)
            {
                return BadRequest();
            }
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
