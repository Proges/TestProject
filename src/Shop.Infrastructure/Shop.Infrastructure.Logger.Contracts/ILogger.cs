using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Logger.Contracts
{   
    public interface ILogger
    {
        void InfoLog(string message);
        void WarningLog(string message);
        void ErrorLog(string message);
        void FatalLog(string message);
        void DebugLog(string message);
        void ExceptionLog(Exception exception);
    }
}
