using Application.Models;
using Core.Entites;
using MediatR;

namespace Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<ResultViewModel<Guid>>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User ToEntity() => new(Id, Name, Email, IsActive, Password);
    }
}
