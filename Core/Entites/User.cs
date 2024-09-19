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
        public Guid? TeamId { get; set; } //  FK (Chave Estrangeira opcional para Equipe)
        public Guid? ManagerProjectId { get; set; } //  FK (Chave Estrangeira manager project)
        public List<tTask> AssignedTasks { get; set; } //Relação 1  (Um Usuário pode ter várias Tarefas atribuídas)
        public List<Project>? ManagementProjects { get; set; } // Relação 1 (Um Usuário pode gerenciar 1 projeto)
        public List<Project>? ParticipaitingProjects { get; set; }  // Relação N  (Um Usuário pode participar de vários Projetos e um Projeto pode ter vários Usuários)
        public bool IsActive { get; set; }

        // TODO COMO DEVE SER FEITO O UPDATE DA MANEIRA CORRETA SEM FAZER A REFERENCIA A CAMADA APPLICATION

        public void UpdateUser(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
