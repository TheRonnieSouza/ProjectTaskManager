using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.DeleteTaskCommand
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public DeleteTaskHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == request.Id);

            if (task == null)
                return ResultViewModel.Error("A task pode ser encontrada ou nao pode ser deletada");
             
            task.SetAsDeleted();
             _context.Update(task);
            await _context.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
