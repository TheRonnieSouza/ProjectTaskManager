using Application.Commands.UserCommands.CreateUserCommand;
using Application.Commands.UserCommands.DeleteUserCommand;
using Application.Commands.UserCommands.UpdateUserCommand;
using Application.Queries.UserQueries.GetAllUsersQueries;
using Application.Queries.UserQueries.GetSearchQueries;
using Application.Queries.UserQueries.GetUserById;
using Infrastructure.Storages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStorageService _storageService;
        public UserController(IMediator mediator, IStorageService service)
        {
            _mediator = mediator;
            _storageService = service;
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }               

        [HttpGet("GetAll")]
        public async  Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            return Ok(result);
        }

        
        [HttpGet("search")]
        public async Task<IActionResult> GetSearch([FromQuery]string search)
        {
            var result = await _mediator.Send(new GetSearchQuery(search));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, command);
        }
                
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("profile-picture")]
        public async Task<IActionResult> PutProfilePicture (IFormFile file)
        {
            var stream = file.OpenReadStream();
            var result = await _storageService.Upload("project-task-manager", file.FileName, stream);

            return Ok(result);
        }
        [HttpGet("all-profile-picture")]
        public async Task<IActionResult> GetAllProfilePicture()
        {
            var allFiles = await _storageService.GetAllFiles("project-task-manager");

            return Ok(allFiles);
        }
        [HttpDelete("delete-profile-picture")]
        public async Task<IActionResult> DeleteProfilePicture(string key)
        {
            var result = await _storageService.Delete("project-task-manager", key);

            return Ok(result);
        }
        [HttpGet("url-profile-picture")]
        public async Task<IActionResult> GetUrl(string key)
        {
            var result = await _storageService.UrlGenerator("project-task-manager", key);

            return Ok(result);
        }
    }

}
