namespace Core.Entites
{
    public class Tag : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<tTask> Tasks { get; set; } 
    }
}
