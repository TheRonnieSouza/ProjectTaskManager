﻿

using Domain.Entites;

namespace Domain.Entities.Tasks.InputModel
{
    public class CreateTaskInputModel
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsCompleted { get; set; }



        public  tTask ToEntity() =>
            new (Id, Title, Description, DeliveryDate, UserId, Priority, ProjectId);

    }   
}
