using Application.Models.Tasks.InputModel;
using Application.Models.Tasks.ViewModels;
using Application.Services;
using Core.Enums;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

         public TaskController(ITaskService taskService)
         {
            _taskService = taskService;
         }

        //Delete api/task/1234
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            var result = _taskService.DeleteTask(id);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        //GET api/task/
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var result = _taskService.GetAllTasks();

             return Ok(result);
        }

        
        //Get api/task/user
        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            var result = _taskService.GetTaskById(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //Post api/task/
        [HttpPost]
        public IActionResult PostCreateTask(CreateTaskInputModel model)
        {
            var result = _taskService.CreateTask(model);

            return CreatedAtAction(nameof(GetTaskById), new { id = result.Data}, model);
        }

        

        //Put api/task/1234
        [HttpPut("update-task/{id}")]
        public IActionResult UpdateTask(Guid id, UpdateTaskInputModel inputModel)
        {
            var result = _taskService.UpdateTask(id, inputModel);

            if (result == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AssingTasksToUsers(Guid id, Guid idUser)
        {
            var task = _taskService.AssingTasksToUsers(id, idUser);
            return Ok();            
        }       
        
    }
}
