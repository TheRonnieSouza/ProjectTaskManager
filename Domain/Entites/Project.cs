using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Project : BaseEntity
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public User Manager { get; set; }
        public Guid ManagerId { get; set; } // FK (Chave Estrangeira para Usuário)
        public List<tTask> Tasks { get; set; } //Relação 1 (Um Projeto pode ter várias Tarefas)

        public Guid ParticipaintingId { get; set; } // FK (Chave Estrangeira para Usuário)
        public List<User> Participants {  get; set; } // Relação N  (Um Projeto pode ter vários Usuários participantes)
    }
}
