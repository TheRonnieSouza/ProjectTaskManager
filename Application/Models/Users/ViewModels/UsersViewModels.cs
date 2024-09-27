using Core.Entites;

namespace Application.Models.Users.ViewModels
{
    public class UsersViewModels
    {
        public UsersViewModels() { }
        public UsersViewModels(Guid id,string name, string email, bool isActive)
        {
            Id = id;  Name = name; Email = email; IsActive = isActive;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public static UsersViewModels FromEntity(User users) =>
                      new(users.Id
                          ,users.Name
                          , users.Email
                          , users.IsActive);
    }
}
