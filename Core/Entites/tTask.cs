using Core.Enums;

namespace Core.Entites
{
    public class tTask : BaseEntity
    {
        public tTask() : base() { }
        public tTask(Guid id , Guid? userId, Guid projectId, string title, string description, DateTime deliveryDate,
                     EnumTaskPriority priority) : base()
        { 
            Id = id; 
            Title = title;
            Description = description;
            DeliveryDate = deliveryDate;
            UserId = userId;
            Status = EnumTaskStatus.NotStarted;
            Priority = priority;
            ProjectId = projectId;
            Comments = [];
            Tags = [];
        }

        
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public EnumTaskStatus Status { get; set; }        
        public EnumTaskPriority Priority { get; set; }
        public Project Project { get; set; }         
        public List<Comment>? Comments { get; set; } 
        public List<Tag>? Tags { get; set; } 


        //TODO 

        //public void Update(UpdateTaskInputModel updateTaskModel)// string title, string description, EnumTaskPriority priority, DateTime deliveryDate)
        //{
        //    Title = updateTaskModel.Title;
        //    Description = updateTaskModel.Description;
        //    Priority = updateTaskModel.Priority;
        //    DeliveryDate = updateTaskModel.DeliveryDate;
        //}
        public void AssingTasksToUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
