using Application.Models;
using MediatR;

namespace Application.Commands.TaskCommand.AssingTasksToUsersCommand
{
    public class AssingTasksToUsersCommand : IRequest<ResultViewModel>
    {
        public Guid TaskId{ get; set; }
        public Guid UserId { get; set; }

        public void AssingTasksToUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
