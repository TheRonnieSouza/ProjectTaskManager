using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notification.UserCreated
{
    public class UserCreatedNotification : INotification
    {
        public UserCreatedNotification(Guid userId, string email, string userName)
        {
            UserId = userId;
            Email = email;
            UserName = userName;
        }

        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
    }
}
