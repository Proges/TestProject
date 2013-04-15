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
        DataContext GetContext();
        void Commit();
        void Rollback();
    }
}
