using Core.Enums;

namespace Core.Entites
{
    public class tTask : BaseEntity
    {
        public tTask() : base() { }
        public tTask(Guid id ,string title, string description, DateTime deliveryDate,
                    Guid userId, EnumTaskPriority priority,Guid projectId) : base()
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
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public EnumTaskStatus Status { get; set; }
        public Guid UserId { get; set; } // FK (Chave Estrangeira para Usuário)
        public EnumTaskPriority Priority { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }  //FK (Chave Estrangeira opcional para Projeto)
        public List<Comment>? Comments { get; set; } // Relação 1 (Uma Tarefa pode ter vários Comentários)
        public List<Tag>? Tags { get; set; } //Relação N        (Uma Tarefa pode ter várias Tags e uma Tag pode estar em várias Tarefas)


        //TODO - Duvida se aqui devo ter uma referencia de using da camada application, como devo fazer o update corretamente? 

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
