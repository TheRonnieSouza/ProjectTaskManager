using Application.Commands.UserCommands.CreateUserCommand;
using Application.Commands.UserCommands.DeleteUserCommand;
using Application.Commands.UserCommands.UpdateUserCommand;
using Application.Models.Users.InputModels;
using Application.Queries.UserQueries.GetAllUsersQueries;
using Application.Queries.UserQueries.GetSearchQueries;
using Application.Queries.UserQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //Delete api/users/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }               

        [HttpGet]
        public async  Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            return Ok(result);
        }

        //Get api/users?search=crm
        [HttpGet("search")]
        public async Task<IActionResult> GetSearch(string search)
        {
            var result = await _mediator.Send(new GetSearchQuery(search));

            return Ok(result);
        }

        //Get api/users/1234
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

        //Post api/users/
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, command);
        }

        //Put api/users/1234
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public  IActionResult PutProfilePicture (IFormFile file)
        {
            var description =  $"File : {file.FileName}, Size: {file.Length}";

            return Ok(description);
        }
    }

}
