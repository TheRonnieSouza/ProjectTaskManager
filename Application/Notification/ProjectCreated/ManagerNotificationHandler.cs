using MediatR;

namespace Application.Notification.ProjectCreated
{
    public class ManagerNotificationHandler : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notificando a criação do projeto {notification.Name}, para o Gestor.");
            return Task.CompletedTask;
        }
    }
}
