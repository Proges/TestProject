using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.ContextFactory.Contracts
{
    public interface IDbSession
    {
        IContextFactory ContextFactory { get; }
    }
}
