using MediatR;

namespace Application.Notification.ProjectCreated
{
    public class GenerateProjectBoardHandler : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Criando o painel para o projeto: {notification.Name}.");
            return Task.CompletedTask;
        }
    }
}
