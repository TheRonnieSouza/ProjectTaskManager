namespace Core.Entites
{
    public class Project : BaseEntity
    {
        public Project() { }
        
        public Project(string name, string description, Guid managerId) 
        {
            Name = name;
            Description = description;
            ManagerId = managerId;
        }


        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //TODO Colocar centro de custo
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public User Manager { get; set; }
        public Guid ManagerId { get; set; } 
        public List<tTask> Tasks { get; set; } 

        public Guid ParticipaintingId { get; set; } 
        public List<User> Participants {  get; set; }
    }
}
