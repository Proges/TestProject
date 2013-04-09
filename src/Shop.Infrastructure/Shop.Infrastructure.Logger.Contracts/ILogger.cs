using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Logger.Contracts
{   
    public interface ILogger
    {
        void WriteLog(string message);
    }
}
