using Core.Entites;
using Core.Enums;

namespace Application.Models.Users.InputModels
{
    public class CreateUserInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Profile Password { get; set; }
        public bool IsActive { get; set; }

        public User ToEntity() => new(Id, Name, Email, IsActive, Password);
    }
}
