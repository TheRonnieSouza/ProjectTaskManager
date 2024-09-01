using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Comment : BaseEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Guid TaskId { get; set; } //FK (Chave Estrangeira para Tarefa)
        public Guid AutorId { get; set; } //FK (Chave Estrangeira para Usuário)

        public tTask Task { get; set; }
    }
}
