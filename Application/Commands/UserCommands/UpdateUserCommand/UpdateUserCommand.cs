using Application.Models;
using Application.Models.Users.InputModels;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
    }
}
