using Application.Models;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {
        public DeleteUserCommand(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
