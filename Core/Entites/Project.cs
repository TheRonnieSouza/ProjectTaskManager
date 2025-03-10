﻿namespace Core.Entites
{
    public class Project : BaseEntity
    {
        public Project() { }
        
        public Project(Guid id, string name, string description, Guid managerId) 
        {
            Id = id;
            Name = name;
            Description = description;
            ManagerId = managerId;
        }
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? CompletedDate { get; set; }
        public User Manager { get; set; }
        public Guid ManagerId { get; set; } 
        public List<tTask> Tasks { get; set; } 
        public Guid ParticipatingId { get; set; } 
        public List<User> Participants {  get; set; }

        public void UpdateProject(string? description, DateTime? completeDate, Guid managerId, Guid participatingId)
        {
            Description = description;
            CompletedDate = completeDate;
            ManagerId = managerId;
            ParticipatingId = participatingId;
        }
    }
}
