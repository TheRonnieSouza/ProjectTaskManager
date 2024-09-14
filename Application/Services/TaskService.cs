using Application.Models;
using Application.Models.Tasks.InputModel;
using Application.Models.Tasks.ViewModels;
using Core.Enums;
using Infrastructure.Persistence;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ProjectTaskManagerDbContext _context;

        public TaskService(ProjectTaskManagerDbContext context)
        {
            _context = context; 
        }

        public ResultViewModel AssingTasksToUsers(Guid id, Guid idUser)
        {
            var task = _context.Tasks.SingleOrDefault(t => t.Id == id).AssingTasksToUser;

            if (task == null)
                return ResultViewModel.Error("Projeto nao existe.");

            return ResultViewModel.Success();
        }

        public ResultViewModel DeleteTask(Guid id)
        {
            //todo
            //Remover uma tarefa específica do sistema, garantindo que a tarefa seja identificada corretamente.

            var task = _context.Tasks.SingleOrDefault(t => t.Id == id).SetAsDeleted;

            if (task == null)
                return ResultViewModel.Error("A task pode ser encontrada ou nao pode ser deletada");

            _context.Update(task);
            _context.SaveChanges();

           
            return ResultViewModel.Success();
        }

        public ResultViewModel<List<GetTaskViewModel>> GetAllTasks()
        {
            //TODO
            //Permitir a consulta de todas as tarefas registradas no sistema.
            //Oferecer filtros para buscar tarefas por status (pendente, em progresso, concluída).

            var tasks = _context.Tasks.Where(t => t.Status != EnumTaskStatus.Completed);

            if (tasks == null)
                return ResultViewModel<List<GetTaskViewModel>>.Error("Nao existe tasks encontrada");

            var model = tasks.Select(GetTaskViewModel.FromEntity).ToList();

             return ResultViewModel<List<GetTaskViewModel>>.Success(model);
        }

        public ResultViewModel<GetTaskViewModel> GetTaskById(Guid id)
        {
            //TODO 
            //Buscar e exibir detalhes de uma tarefa específica, solicitando o identificador (Id) da tarefa.

            var task = _context.Tasks.Where(t => t.Status != EnumTaskStatus.Completed)
                                     .FirstOrDefault(ta => ta.Id == id);

            if (task == null)
            {
                return ResultViewModel<GetTaskViewModel>.Error("Task nao encontrada");
            }
                var model = GetTaskViewModel.FromEntity(task);

            return ResultViewModel<GetTaskViewModel>.Success(model);
        }

        public ResultViewModel<Guid> CreateTask(CreateTaskInputModel inputModel)
        {
            //TODO
            //Validar os dados fornecidos, como título, descrição, e data de vencimento(PLUS 1).
            //Garantir que cada tarefa esteja associada a um usuário específico.

            var task = inputModel.ToEntity();

             _context.Tasks.Add(task);
             _context.SaveChanges();

            return ResultViewModel<Guid>.Success(task.Id);
        }

        public ResultViewModel UpdateTask(UpdateTaskInputModel inputModel)
        {
            //TODO
            // Permitir a atualização dos dados de uma tarefa específica, incluindo título, descrição, status e data de vencimento.
            // Validar que as alterações estejam de acordo com as regras de negócio, como uma data de vencimento futura.
            //task.Update(inputModel);

            var task = _context.Tasks.SingleOrDefault(t => t.Id == inputModel.Id);

            if (task == null)
            {
                return ResultViewModel.Error("Nao foi possivel atualizar a task");
            }          

            _context.Update(task);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
