using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.UpdateTaskCommand
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public UpdateTaskHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            //TODO
            // Permitir a atualização dos dados de uma tarefa específica, incluindo título, descrição, status e data de vencimento.
            // Validar que as alterações estejam de acordo com as regras de negócio, como uma data de vencimento futura.
            //task.Update(inputModel);

            var task = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == request.Id);

            if (task == null)
            {
                return ResultViewModel.Error("Nao foi possivel atualizar a task");
            }          

            _context.Update(task);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
