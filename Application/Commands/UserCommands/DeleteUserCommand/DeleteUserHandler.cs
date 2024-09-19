using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UserCommands.DeleteUserCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public DeleteUserHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
                return ResultViewModel.Error("O usuario nao pode ser deletado ou nao fo encontrado");

            user.SetAsDeleted();
            _context.Update(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
