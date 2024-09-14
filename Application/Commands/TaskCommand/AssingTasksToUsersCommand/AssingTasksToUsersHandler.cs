using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.AssingTasksToUsersCommand
{
    public class AssingTasksToUsersHandler : IRequestHandler<AssingTasksToUsersCommand, ResultViewModel>     
    {
        private readonly ProjectTaskManagerDbContext _context;

        public AssingTasksToUsersHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(AssingTasksToUsersCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == request.Id);

            if (task == null)
                return ResultViewModel.Error("Projeto nao existe.");

            task.AssingTasksToUser(request.Id);

            return ResultViewModel.Success();
        }
    }
}
