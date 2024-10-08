using MediatR;

namespace Application.Notification.TaskCreated
{
    public class TaskCreatedNotification :INotification
    {
        public TaskCreatedNotification(Guid id, Guid userId, Guid projectId, string title, string projectName, string? user = null)
        {
            Id = id;
            Title = title;
            ProjectName = projectName;
            User = user;
            UserId = userId;
            ProjectId = projectId;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ProjectId { get; private set; }
        public string? User { get; private set; }
        public string Title { get; private set; }
        public string ProjectName { get; private set; }
    }
}
