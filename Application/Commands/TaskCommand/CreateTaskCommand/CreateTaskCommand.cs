using Application.Models;
using Application.Models.Tasks.InputModel;
using Core.Entites;
using Core.Enums;
using MediatR;

namespace Application.Commands.TaskCommand.CreateTaskCommand
{
    public class CreateTaskCommand : IRequest<ResultViewModel<Guid>>
    {
        
        public Guid Id { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        public Guid ProjectId { get; set; } = Guid.Empty;
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsCompleted { get; set; }
        public tTask ToEntity() =>
            new(Id, Title, Description, DeliveryDate, UserId, Priority, ProjectId);

    }
}
