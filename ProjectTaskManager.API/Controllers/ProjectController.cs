using Application.Commands.ProjectCommand.CreateProjectCommand;
using Application.Models.Projects.InputModels;
using Application.Queries.UserQueries.GetUserById;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectTaskManager.API.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> CreateProject( CreateProjectCommand command)
        {

            var result = await _mediator.Send(command);  //_projectService.CreateProject(inputModel);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetProjectById), new { id = result.Data }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
 