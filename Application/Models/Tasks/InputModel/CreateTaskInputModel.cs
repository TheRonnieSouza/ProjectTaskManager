using Core.Entites;
using Core.Enums;

namespace Application.Models.Tasks.InputModel
{
    public class CreateTaskInputModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsCompleted { get; set; }
        public tTask ToEntity() =>
            new(Id, UserId, ProjectId, Title, Description, DeliveryDate, Priority);
    }
}
