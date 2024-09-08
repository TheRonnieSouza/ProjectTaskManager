using Core.Entites;

namespace Application.Models.Users.ViewModels
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
