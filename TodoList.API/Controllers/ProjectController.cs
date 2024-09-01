using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoList.API.Controllers
{
    public class ProjectController : Controller
    {
        private readonly DbContext _context;
        public ProjectController(DbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public IActionResult CreateProject()
        {
            return View();
        }
    }
}
