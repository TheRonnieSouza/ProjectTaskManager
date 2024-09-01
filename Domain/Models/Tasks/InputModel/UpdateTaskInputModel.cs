

namespace Domain.Entities.Tasks.InputModel
{
    public class UpdateTaskInputModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
