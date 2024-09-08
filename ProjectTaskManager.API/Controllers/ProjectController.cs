using Application.Models.Projects.InputModels;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectTaskManager.API.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService service)
        {
            _projectService = service;
        }

        [HttpPut]
        public IActionResult CreateProject(CreateProjectInputModel inputModel)
        {
            var result = _projectService.CreateProject(inputModel);

            return CreatedAtAction(nameof(GetProjectById), new { id = result.Data }, inputModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(Guid id)
        {
            var result = _projectService.GetProjectById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
 