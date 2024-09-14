using Application.Models;
using Application.Models.Tasks.InputModel; 
using Core.Enums;
using MediatR;

namespace Application.Commands.TaskCommand.UpdateTaskCommand
{
    public class UpdateTaskCommand : IRequest<ResultViewModel>
    {
        public UpdateTaskCommand(UpdateTaskInputModel model, Guid id )
        {
            Id = model.Id;
            UserId = model.UserId;
            Title = model.Title;
            Description = model.Description;
            DeliveryDate = model.DeliveryDate;
            Priority = model.Priority;
            IsCompleted = model.IsCompleted;
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }
        

    }
}
