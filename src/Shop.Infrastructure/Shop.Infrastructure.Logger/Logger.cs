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
using System.Data.SqlClient;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using System.Configuration;

namespace Shop.Infrastructure.Logger
{
    public class Logger : ILogger
    {
        private ILog log;        

        public Logger()
        {
            log = LogManager.GetLogger("ShopLogger");            
        }        
       
        public void InfoLog(string message)
        {
            string type = "INFO";
            SetGlobalContext(type);
            log.InfoFormat(message);
        }

        public void WarningLog(string message)
        {
            string type = "WARNING";
            SetGlobalContext(type);
            log.Warn(message);
        }

        public void ErrorLog(string message)
        {               
            string type = "ERROR";
            SetGlobalContext(type);
            log.Error(message);           
        }

        public void FatalLog(string message)
        {                
            string type = "FATAL";
            SetGlobalContext(type);
            log.Fatal(message);
        }

        public void DebugLog(string message)
        {                
            string type = "DEBUG";
            SetGlobalContext(type);
            log.Debug(message);           
        }

        public void ExceptionLog(Exception exception)
        {                
            string type = "EXCEPTION";
            SetGlobalContext(type);
            log.Error(exception.Message);
        }

        private void SetGlobalContext(string type)
        {
            GlobalContext.Properties["Location"] = Assembly.GetCallingAssembly().GetName().Name;
            GlobalContext.Properties["Type"] = type;
        }

       
        public void InfoFormatLog(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }

        public void WarningFormatLog(string format, params object[] args)
        {
            log.WarnFormat(format, args);
        }

        public void ErrorFormatLog(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }

        public void FatalFormatLog(string format, params object[] args)
        {
            log.FatalFormat(format, args);
        }

        public void DebugFormatLog(string format, params object[] args)
        {
            log.DebugFormat(format, args);
        }

        public void ExceptionFormatLog(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }
    }
}
