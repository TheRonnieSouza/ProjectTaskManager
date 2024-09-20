namespace Core.Entites
{
    public class Comment : BaseEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Guid TaskId { get; set; } 
        public Guid AutorId { get; set; }

        public tTask Task { get; set; }
    }
}
