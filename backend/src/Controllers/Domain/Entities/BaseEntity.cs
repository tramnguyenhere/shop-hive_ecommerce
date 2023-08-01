using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Controllers.Domain.Entities
{
    public abstract class BaseEntity
    {
        private Guid _id;

        public Guid Id {
            get { return _id; }
            set {_id = value; }
        }
    }
}