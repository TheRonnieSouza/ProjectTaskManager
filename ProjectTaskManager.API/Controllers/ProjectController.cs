using Application.Commands.ProjectCommand.CreateProjectCommand;
using Application.Commands.ProjectCommand.ProjectDeleteCommand;
using Application.Commands.ProjectCommand.UpdateProjectCommand;
using Application.Queries.ProjectQueries.GetAllProjectQuery;
using Application.Queries.UserQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject( CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);  

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetProjectById), new { id = result.Data }, command);
        }

        [HttpGet("Get-One/{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllProject()
        {
            var result = await _mediator.Send(new GetAllProjectQuery());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ProjectDelete(Guid id)
        {
            var result = await _mediator.Send(new ProjectDeleteCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
 