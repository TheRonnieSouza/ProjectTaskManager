

using Domain.Entites;

namespace Domain.Entities.Users.InputModels
{
    public class CreateUserInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User ToEntity() => new(Id, Name, Email, IsActive);
    }
}
