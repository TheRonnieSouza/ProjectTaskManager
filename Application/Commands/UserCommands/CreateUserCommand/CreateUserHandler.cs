using Application.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserHandler :IRequestHandler<CreateUserCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public CreateUserHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO 
            //Permitir o cadastro de novos usuários no sistema, validando informações como nome e email (PLUS 1).
            //Garantir que cada usuário possua um identificador único.
            //
            var newUser = request.ToEntity();

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return ResultViewModel<Guid>.Success(newUser.Id);
        }
    }
}
