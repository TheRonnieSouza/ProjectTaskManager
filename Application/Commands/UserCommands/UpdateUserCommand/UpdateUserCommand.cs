using Application.Models;
using Application.Models.Users.InputModels;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public UpdateUserCommand(Guid id, UpdateUserInputModel model)
        {
            Id = id;
            IdUpdate = model.Id;
            Name = model.Name;
            Email = model.Email;
        }
        public Guid Id { get; private set; }
        public Guid IdUpdate { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
