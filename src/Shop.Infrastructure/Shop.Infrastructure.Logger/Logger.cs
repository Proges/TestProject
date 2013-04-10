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
            //TODO: make relative path
            FileInfo info = new FileInfo("D:\\ENTERPRISE\\Workshop\\TestProject\\src\\Shop.Infrastructure\\Shop.Infrastructure.Logger\\log4net.config");
            XmlConfigurator.ConfigureAndWatch(info);
            log = LogManager.GetLogger("ShopLogger"); 

        }

        public void InfoLog(string message)
        {
            log.Info(message);
        }

        public void WarningLog(string message)
        {
            log.Warn(message);
        }

        public void ErrorLog(string message)
        {
            log.Error(message);
        }

        public void FatalLog(string message)
        {
            log.Fatal(message);
        }
    }
}
