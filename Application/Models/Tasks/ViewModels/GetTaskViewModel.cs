using Core.Entites;
using Core.Enums;

namespace Application.Models.Tasks.ViewModels
{
    public class GetTaskViewModel
    {
        public GetTaskViewModel() { }
        public GetTaskViewModel(Guid id, string title, string description,
                                DateTime deliveryDate, EnumTaskStatus status,
                                EnumTaskPriority priority, List<Comment> comments,
                                Project project, List<Tag> tags)
        {
            Id = id; Title = title;
            Description = description;
            DeliveryDate = deliveryDate;
            Status = status;
            Priority = priority;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public EnumTaskStatus Status { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public List<string>? Comments { get; set; }
        public string? Project { get; set; }
        public List<string>? Tags { get; set; }
        public static GetTaskViewModel FromEntity(tTask entity) => new(entity.Id, entity.Title, entity.Description, entity.DeliveryDate,
                                                                entity.Status, entity.Priority, entity.Comments, entity.Project, entity.Tags);
    }
}
