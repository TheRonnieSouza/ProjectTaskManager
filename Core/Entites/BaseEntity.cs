namespace Core.Entites
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
