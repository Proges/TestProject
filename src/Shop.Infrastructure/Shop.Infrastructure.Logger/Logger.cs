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
            string type = "INFO";
            log.InfoFormat("Date: {0}\nLocation: {1}\n" + type + ": {2}", DateTime.Now, location, message);
            WriteLogToDb(location, type, message);
        }

        public void WarningLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;       
            string type = "WARNING";
            log.WarnFormat("Date: {0}\nLocation: {1}\n" + type + ": {2}", DateTime.Now, location, message);
            WriteLogToDb(location, type, message);
        }

        public void ErrorLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            string type = "ERROR";
            log.ErrorFormat("Date: {0}\nLocation: {1}\n" + type + ": {2}", DateTime.Now, location, message);
            WriteLogToDb(location, type, message);
        }

        public void FatalLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            string type = "FATAL";
            log.FatalFormat("Date: {0}\nLocation: {1}\n" + type + ": {2}", DateTime.Now, location, message);
            WriteLogToDb(location, type, message);
        }

        public void DebugLog(string message)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            string type = "DEBUG";
            log.DebugFormat("Date: {0}\nLocation: {1}\n" + type + ": {2}", DateTime.Now, location, message);
            WriteLogToDb(location, type, message);
        }

        public void ExceptionLog(Exception exception)
        {
            string location = Assembly.GetCallingAssembly().GetName().Name;
            string type = "EXCEPTION";
            log.ErrorFormat("Date: {0}\nLocation: {1}\n" + type + ": {2}", DateTime.Now, location, exception.Message);
            WriteLogToDb(location, type, exception.Message);
        }

        public void WriteLogToDb(string location, string type, string message)
        {
            string conString = "";

             var hierarchy = LogManager.GetRepository() as Hierarchy;

             if (hierarchy != null && hierarchy.Configured)
             {
                 foreach (IAppender appender in hierarchy.GetAppenders())
                 {
                     if (appender is AdoNetAppender)
                     {
                         var adoNetAppender = (AdoNetAppender)appender;
                         conString = adoNetAppender.ConnectionString;
                         break;
                     }
                 }
             }

             if (conString == "")
             {
                 return;
             }

             using (SqlConnection con = new SqlConnection(conString))
             {
                 con.Open();                 

                 string sql = "INSERT INTO Logs (Date, Location, Type, Message) VALUES ('" + DateTime.Now + "', '" + location + "', '" + type + "', '" + message + "');";
                 SqlCommand cmd = new SqlCommand(sql, con);
                 cmd.ExecuteNonQuery();
             }
        }
    }
}
