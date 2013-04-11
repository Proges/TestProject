using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Factory;
using Shop.Infrastructure.Logger.Contracts;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Shop.Infrastructure.Logger.Tests
{
    [TestClass]
    public class LoggerTests
    {
        string path = "";

        [TestMethod]
        public void WriteLogTest()
        {
            var logger = Factory.Factory.GetComponent<ILogger>();
            log4net.Config.XmlConfigurator.Configure();

            var infoLog = "InfoTEST";
            var warningLog = "WarningTEST";
            var errorLog = "ErrorTEST";
            var fatalLog = "FatalTEST";
            var debugLog = "DebugTest";
            var exceptionLog = new InvalidCastException().Message;

            logger.InfoLog(infoLog);
            logger.WarningLog(warningLog);
            logger.ErrorLog(errorLog);
            logger.FatalLog(fatalLog);
            logger.DebugLog(debugLog);
            logger.ExceptionLog(new InvalidCastException());

            path = AppDomain.CurrentDomain.BaseDirectory + "/Log.log";
            var logString = "";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "" || line == " ")
                    {
                        continue;
                    }
                    if (line.Contains(infoLog)
                        || line.Contains(warningLog)
                        || line.Contains(errorLog)
                        || line.Contains(fatalLog)
                        || line.Contains(debugLog)
                        || line.Contains(exceptionLog))
                    {
                        logString += line;
                    }
                    
                }

                Assert.IsTrue(logString.Contains(infoLog));
                Assert.IsTrue(logString.Contains(warningLog));
                Assert.IsTrue(logString.Contains(errorLog));
                Assert.IsTrue(logString.Contains(fatalLog));
                Assert.IsTrue(logString.Contains(debugLog));
                Assert.IsTrue(logString.Contains(exceptionLog));               
            }                     
        }

        [TestCleanup]
        public void CleanTests()
        {
            if (path != "")
            {
               File.Delete(path);
            }
        }
    }
}
