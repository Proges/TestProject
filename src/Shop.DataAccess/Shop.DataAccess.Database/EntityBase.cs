using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual bool IsValid { get { return true; } }
        public virtual void Validate() { }
        public virtual string GetErrors() { return ""; }
    }
}
