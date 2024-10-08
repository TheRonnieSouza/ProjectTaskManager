using MediatR;

namespace Application.Notification.TaskCreated
{
    public class GenerateBoardBacklogHandler : INotificationHandler<TaskCreatedNotification>
    {
        public Task Handle(TaskCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Creating board of the task: {notification.Title}, in project backlog {notification.ProjectName}, id: {notification.ProjectId}.");

            return Task.CompletedTask;
        }
    }
}
