using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.ContextFactory.Contracts
{
    public interface IContextFactory
    {
        ChangeSet GetChanges { get; }
        DataContext GetContext();        
        void Commit();
        void Rollback();
    }
}
