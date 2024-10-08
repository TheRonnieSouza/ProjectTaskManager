using MediatR;

namespace Application.Notification.UserCreated
{
    public class WelcomeEmailNotificationHandler : INotificationHandler<UserCreatedNotification>
    {
        public Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Sending the welcoming email to new user: {notification.UserName}, id: {notification.UserId}, email: {notification.Email}");
            return Task.CompletedTask;
        }
    }
}
