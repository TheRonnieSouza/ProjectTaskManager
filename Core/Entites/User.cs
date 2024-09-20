namespace Core.Entites
{
    public class User : BaseEntity
    {
        public User() : base()   { } 
        public User(Guid id, string name, string email, bool isActive, string password) : base()
        { 
            Id = id;
            Name = name;
            Email = email;
            IsActive = isActive;
            Password = password; 
        }
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? TeamId { get; set; }                           
        public Guid? ManagerProjectId { get; set; }                 
        public List<tTask>? AssignedTasks { get; set; }             
        public List<Project>? ManagementProjects { get; set; }      
        public List<Project>? ParticipaitingProjects { get; set; }  
        public bool IsActive { get; set; }

        // TODO Update

        public void UpdateUser(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
