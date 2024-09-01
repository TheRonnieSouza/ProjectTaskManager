using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users.ViewModels
{
    public class UsersViewModels
    {
        public UsersViewModels() { }
        public UsersViewModels(string name, string email, bool isActive)
        {
            Name = name; Email = email; IsActive = isActive;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public static UsersViewModels FromEntity(User users) =>
                      new(users.Name
                          , users.Email
                          , users.IsActive);
        
    }
}
