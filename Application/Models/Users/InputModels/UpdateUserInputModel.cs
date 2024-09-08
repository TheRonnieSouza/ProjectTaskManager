namespace Application.Models.Users.InputModels
{
    public class UpdateUserInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}