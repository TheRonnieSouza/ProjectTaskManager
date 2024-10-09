using Application.Commands.TaskCommand.AssingTasksToUsersCommand;
using Application.Commands.TaskCommand.CreateTaskCommand;
using Application.Commands.TaskCommand.DeleteTaskCommand;
using Application.Commands.TaskCommand.UpdateTaskCommand;
using Application.Queries.TaskQueries.GetAllTasks;
using Application.Queries.TaskQueries.GetTaskById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ProjectTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

         public TaskController(IMediator mediator)
         {
            _mediator = mediator;
         }

        //Delete api/task/1234
        [HttpDelete("One/{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        //GET api/task/
        [HttpGet("All")]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _mediator.Send(new GetAllTasksQuery());

             return Ok(result);
        }

        
        //Get api/task/user
        [HttpGet("Get-One/{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var result = await _mediator.Send(new GetTaskByIdQuery(id));

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //Post api/task/
        [HttpPost]
        public async Task<IActionResult> PostCreateTask(CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetTaskById), new { id = result.Data}, command);
        }

        

        //Put api/task/1234
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(UpdateTaskCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }

        [HttpPut("Assign-Task-For-User")]
        public async Task<IActionResult> AssignTasksToUsers(AssingTasksToUsersCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }       
        
    }
}
