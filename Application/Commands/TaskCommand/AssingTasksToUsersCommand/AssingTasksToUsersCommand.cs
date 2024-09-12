using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.AssingTasksToUsersCommand
{
    public class AssingTasksToUsersCommand : IRequest<ResultViewModel>
    {
        public AssingTasksToUsersCommand(Guid id, Guid userId) 
        { 
            Id = id;
            UserId = userId;
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public void AssingTasksToUser(Guid userId)
        {
            UserId = userId;
        }
    }
    
    public class AssingTasksToUsersHandler : IRequestHandler<AssingTasksToUsersCommand, ResultViewModel>     
    {
        private readonly ProjectTaskManagerDbContext _context;

        public AssingTasksToUsersHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(AssingTasksToUsersCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == request.Id).AssingTasksToUser;

            if (task == null)
                return ResultViewModel.Error("Projeto nao existe.");

            return ResultViewModel.Success();
        }
    }
}
