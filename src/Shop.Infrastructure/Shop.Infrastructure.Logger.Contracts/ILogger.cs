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
        void InfoFormatLog(string format, params object[] args);
        void WarningFormatLog(string format, params object[] args);
        void ErrorFormatLog(string format, params object[] args);
        void FatalFormatLog(string format, params object[] args);
        void DebugFormatLog(string format, params object[] args);
        void ExceptionFormatLog(string format, params object[] args);
    }
}
