using Application.Models;
using Application.Models.Tasks.InputModel;
using Core.Entites;
using Core.Enums;
using MediatR;

namespace Application.Commands.TaskCommand.CreateTaskCommand
{
    public class CreateTaskCommand : IRequest<ResultViewModel<Guid>>
    {
        public CreateTaskCommand(CreateTaskInputModel inputModel) 
        {
            Id = inputModel.Id;
            UserId = inputModel.UserId;
            ProjectId = inputModel.ProjectId;
            Title = inputModel.Title;
            Description = inputModel.Description;
            Priority = inputModel.Priority;
            DeliveryDate = inputModel.DeliveryDate;
            IsCompleted = inputModel.IsCompleted;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsCompleted { get; set; }
        public tTask ToEntity() =>
            new(Id, Title, Description, DeliveryDate, UserId, Priority, ProjectId);

    }
}
