using MediatR;

namespace Application.Notification.ProjectCreated
{
    public class ProjectCreatedNotification : INotification
    {
        public ProjectCreatedNotification(Guid id, Guid managerId, string name)
        {
            Id = id;
            Name = name;
            ManagerId = managerId;
        }

        public Guid Id { get; private set; }
        public Guid ManagerId { get; private set; }
        public string Name { get; private set; }

    }
}
