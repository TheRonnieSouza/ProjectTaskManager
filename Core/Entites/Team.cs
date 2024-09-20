namespace Core.Entites
{
    public class Team : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; } 
        public List<Project> Projects { get; set; } 

    }
}
