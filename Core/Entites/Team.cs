using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Team : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; } //Relação 1  (Uma Equipe pode ter vários Usuários)
        public List<Project> Projects { get; set; } //Relação 1   (Uma Equipe pode gerenciar vários Projetos)

    }
}
