using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Tag : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<tTask> Tasks { get; set; } // Relação N   (Uma Tag pode estar em várias Tarefas e uma Tarefa pode ter várias Tags)
    }
}
