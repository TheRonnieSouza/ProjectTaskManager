using Application.Models;
using Application.Models.Tasks.ViewModels;
using Core.Enums;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksCommand, ResultViewModel<List<GetTaskViewModel>>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public GetAllTasksHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<GetTaskViewModel>>> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
        {
            //TODO
            //Permitir a consulta de todas as tarefas registradas no sistema.
            //Oferecer filtros para buscar tarefas por status (pendente, em progresso, concluída).

            var tasks = _context.Tasks
                        .Include(t => t.Project)
                        .Include(t => t.Comments)
                        .Include(t => t.Tags)
                        .Where(t => t.Status != EnumTaskStatus.Completed);
                       
            var model = tasks.Select(GetTaskViewModel.FromEntity).ToList();

            return ResultViewModel<List<GetTaskViewModel>>.Success(model);

        }
    }
}
