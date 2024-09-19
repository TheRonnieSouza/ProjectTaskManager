using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UserCommands.UpdateUserCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public UpdateUserHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null) 
                return ResultViewModel.Error("Não foi encontrado nenhum usuário para atualizar");

            user.UpdateUser(request.Name, request.Email);
            _context.Update(user);
            await _context.SaveChangesAsync();

            return  ResultViewModel.Success();
        }
    }
}
