using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure.Logger.Contracts;
using log4net;
using System.Reflection;
using log4net.Config;
using System.IO;

namespace Shop.Infrastructure.Logger
{
    public class Logger : ILogger
    {
        private readonly ILog log;

        public Logger()
        {
            log = LogManager.GetLogger("ShopLogger");
        }
        
       
        public void InfoLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            GlobalContext.Properties["Location"] = location;
            GlobalContext.Properties["Type"] = "INFO";
            log.Info(message);
        }

        public void WarningLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            GlobalContext.Properties["Location"] = location;
            GlobalContext.Properties["Type"] = "WARNING";
            log.Warn(message);
        }

        public void ErrorLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            GlobalContext.Properties["Location"] = location;
            GlobalContext.Properties["Type"] = "ERROR";
            log.Error(message);
        }

        public void FatalLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            GlobalContext.Properties["Location"] = location;
            GlobalContext.Properties["Type"] = "FATAL";
            log.Fatal(message);
        }

        public void DebugLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            GlobalContext.Properties["Location"] = location;
            GlobalContext.Properties["Type"] = "DEBUG";
            log.Debug(message);
        }

        public void ExceptionLog(Exception exception)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            GlobalContext.Properties["Location"] = location;
            GlobalContext.Properties["Type"] = "EXCEPTION";
            log.Error(exception.Message);
        }
    }
}
