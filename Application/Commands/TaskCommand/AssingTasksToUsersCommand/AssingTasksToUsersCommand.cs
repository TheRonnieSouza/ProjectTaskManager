using Application.Models;
using MediatR;

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
}
