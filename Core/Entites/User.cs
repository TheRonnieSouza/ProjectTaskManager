using Core.Enums;
using System.Text.Json.Serialization;

namespace Core.Entites
{
    public class User : BaseEntity
    {
        public User() : base()   { } 
        public User(Guid id, string name, string email, bool isActive, Profile profile) : base()
        { 
            Id = id;
            Name = name;
            Email = email;
            IsActive = isActive;
            Profile = profile;
        }
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = "default";
        public Guid? TeamId { get; set; }
        public Profile Profile { get; set; }
        public bool IsActive { get; set; }
        public List<tTask>? AssignedTasks { get; set; }
        [JsonIgnore]
        public List<Project>? ManagementProjects { get; set; }
        [JsonIgnore]
        public List<Project>? ParticipaitingProjects { get; set; }  
        

        // TODO Update

        public void UpdateUser(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
