using Domain.Entities.Tasks.InputModel;
using Domain.Models.Tasks.ViewModels;
using Domain.TodoListDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly TodoListDbContext _context;

         public TaskController(TodoListDbContext context)
         {
             _context = context;
         }

        //Delete api/task/1234
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            var task = _context.Tasks.SingleOrDefault(t => t.Id == id).SetAsDeleted;

            if (task == null) { return NotFound(); };

            _context.Update(task);
            _context.SaveChanges();
            //Remover uma tarefa específica do sistema, garantindo que a tarefa seja identificada corretamente.
            return NoContent();
        }

        //GET api/task/
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _context.Tasks.Where(t => t.Status != Domain.EnumTaskStatus.Completed);


            var model = tasks.Select(GetTaskViewModel.FromEntity).ToList();

            //Permitir a consulta de todas as tarefas registradas no sistema.
            //Oferecer filtros para buscar tarefas por status (pendente, em progresso, concluída).
            return Ok(model);
        }

        
        //Get api/task/user
        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = _context.Tasks.Where(t => t.Status != Domain.EnumTaskStatus.Completed)
                                     .FirstOrDefault(ta => ta.Id == id);

            var model = GetTaskViewModel.FromEntity(task);

            //Buscar e exibir detalhes de uma tarefa específica, solicitando o identificador (Id) da tarefa.
            return Ok();
        }

        //Post api/task/
        [HttpPost]
        public IActionResult PostCreateTask(CreateTaskInputModel model)
        {
            var task = model.ToEntity();

            _context.Tasks.Add(task);
            _context.SaveChanges();

            //Validar os dados fornecidos, como título, descrição, e data de vencimento(PLUS 1).
            //Garantir que cada tarefa esteja associada a um usuário específico.
            return CreatedAtAction(nameof(GetTaskById), new { id = "5" }, model);
        }

        

        //Put api/task/1234
        [HttpPut("update-task/{id}")]
        public IActionResult UpdateTask(Guid id, UpdateTaskInputModel inputModel)
        {
            var task = _context.Tasks.SingleOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            task.Update(inputModel);

            _context.Update(task);
            _context.SaveChanges();

           // Permitir a atualização dos dados de uma tarefa específica, incluindo título, descrição, status e data de vencimento.
           // Validar que as alterações estejam de acordo com as regras de negócio, como uma data de vencimento futura.
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AssingTasksToUsers(Guid id, Guid idUser)
        {
            var task = _context.Tasks.SingleOrDefault(t => t.Id == id).AssingTasksToUser;

            if (task == null)
            {  return NotFound(); }
            
            return Ok();
        }       
        
    }
}
