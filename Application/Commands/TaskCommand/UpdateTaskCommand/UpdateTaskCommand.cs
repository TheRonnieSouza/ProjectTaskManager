using Application.Models;
using Application.Models.Tasks.InputModel; 
using Core.Enums;
using MediatR;

namespace Application.Commands.TaskCommand.UpdateTaskCommand
{
    public class UpdateTaskCommand : IRequest<ResultViewModel>
    {
        
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }
        

    }
}
