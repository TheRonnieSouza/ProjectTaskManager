using MediatR;

namespace Application.Notification.TaskCreated
{
    public class UserNotificationHandler : INotificationHandler<TaskCreatedNotification>
    {
        public Task Handle(TaskCreatedNotification notification, CancellationToken cancellationToken)
        {
            if(notification.User != null) 
                Console.WriteLine($"Notification user: {notification.User}, Id: {notification.UserId} about new task: {notification.Title}, in the project {notification.ProjectName}.");

            return Task.CompletedTask;
        }
    }
}
