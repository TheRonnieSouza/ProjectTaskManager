using Application.Models.Tasks.ViewModels;
using Application.Models;
using MediatR;
using Infrastructure.Persistence;
using Core.Enums;

namespace Application.Queries.TaskQueries.GetTaskById
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, ResultViewModel<GetTaskViewModel>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public GetTaskByIdHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<GetTaskViewModel>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            //TODO 
            //Buscar e exibir detalhes de uma tarefa específica, solicitando o identificador (Id) da tarefa.

            var task = _context.Tasks.Where(t => t.Status != EnumTaskStatus.Completed)
                                     .FirstOrDefault(ta => ta.Id == request.Id);

            if (task == null)
            {
                return ResultViewModel<GetTaskViewModel>.Error("Task nao encontrada");
            }
            var model = GetTaskViewModel.FromEntity(task);

            return ResultViewModel<GetTaskViewModel>.Success(model);
        }
    }
}
