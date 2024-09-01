using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
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
