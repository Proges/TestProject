using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Factory;
using Shop.Infrastructure.Logger.Contracts;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using log4net.Repository.Hierarchy;
using log4net;
using log4net.Appender;

namespace Shop.Infrastructure.Logger.Tests
{
    [TestClass]
    public class LoggerTests
    {
        string path = "";
        string infoLog = "InfoTEST";
        string warningLog = "WarningTEST";
        string errorLog = "ErrorTEST";
        string fatalLog = "FatalTEST";
        string debugLog = "DebugTest";
        string infoFormatLog = "INFO: {0}";
        string warningFormatLog = "WARNING: {0}";
        string errorFormatLog = "ERROR: {0}";
        string fatalFormatLog = "FATAL: {0}";
        string debugFormatLog = "DEBUG:{0}";
        string exceptionFormatLog = "EXCEPTION: {0}";
        string exceptionLog = new InvalidCastException().Message;

        ShopTestDataContext db;

        [TestInitialize]
        public void InitTests()
        {
            log4net.Config.XmlConfigurator.Configure();
            var logger = Factory.Factory.GetComponent<ILogger>();            

            logger.InfoLog(infoLog);
            logger.WarningLog(warningLog);
            logger.ErrorLog(errorLog);
            logger.FatalLog(fatalLog);
            logger.DebugLog(debugLog);
            logger.ExceptionLog(new InvalidCastException());

            logger.InfoFormatLog(infoFormatLog, infoLog);
            logger.WarningFormatLog(warningFormatLog, warningLog);
            logger.ErrorFormatLog(errorFormatLog, errorLog);
            logger.FatalFormatLog(fatalFormatLog, fatalLog);
            logger.DebugFormatLog(debugFormatLog, debugLog);
            logger.ExceptionFormatLog(exceptionFormatLog, exceptionLog);

            path = AppDomain.CurrentDomain.BaseDirectory + "/Log.log";
        }


        [TestMethod]
        public void LoggerTests_InfoLog()
        {
            var logString = "";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(infoLog))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(infoLog));
        }

        [TestMethod]
        public void LoggerTests_WarningLog()
        {
            var logString = "";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(warningLog))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(warningLog));
        }

        [TestMethod]
        public void LoggerTests_ErrorLog()
        {
            var logString = "";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(errorLog))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(errorLog));
        }

        [TestMethod]
        public void LoggerTests_FatalLog()
        {
            var logString = "";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(fatalLog))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(fatalLog));
        }

        [TestMethod]
        public void LoggerTests_DebugLog()
        {
            var logString = "";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(debugLog))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(debugLog));
        }

        [TestMethod]
        public void LoggerTests_ExceptionLog()
        {
            var logString = "";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(exceptionLog))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(exceptionLog));
        }


        [TestMethod]
        public void LoggerTests_InfoFormatLog()
        {
            var logString = "";
            var formatString = String.Format(infoFormatLog, infoLog);
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(formatString))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(formatString));
        }


        [TestMethod]
        public void LoggerTests_WarningFormatLog()
        {
            var logString = "";
            var formatString = String.Format(warningFormatLog, warningLog);
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(formatString))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(formatString));
        }

        [TestMethod]
        public void LoggerTests_ErrorFormatLog()
        {
            var logString = "";
            var formatString = String.Format(errorFormatLog, errorLog);
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(formatString))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(formatString));
        }

        [TestMethod]
        public void LoggerTests_FatalFormatLog()
        {
            var logString = "";
            var formatString = String.Format(fatalFormatLog, fatalLog);
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(formatString))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(formatString));
        }


        [TestMethod]
        public void LoggerTests_DebugFormatLog()
        {
            var logString = "";
            var formatString = String.Format(debugFormatLog, debugLog);
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(formatString))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(formatString));
        }


        [TestMethod]
        public void LoggerTests_ExceptionFormatLog()
        {
            var logString = "";
            var formatString = String.Format(exceptionFormatLog, exceptionLog);
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    if (line.Contains(formatString))
                    {
                        logString += line;
                        break;
                    }
                }
            }
            Assert.IsTrue(logString.Contains(formatString));
        }

        [TestMethod]
        public void LoggerTests_WriteLogToDatabase()
        {
            db = new ShopTestDataContext();
            var logMessages = db.Logs.Select(log => log.Message).ToList();

            Assert.IsTrue(logMessages.Contains(infoLog));
            Assert.IsTrue(logMessages.Contains(warningLog));
            Assert.IsTrue(logMessages.Contains(errorLog));
            Assert.IsTrue(logMessages.Contains(fatalLog));
            Assert.IsTrue(logMessages.Contains(debugLog));
            Assert.IsTrue(logMessages.Contains(exceptionLog));          
        }    
        
        [TestCleanup]
        public void CleanTests()
        {
            if (path != "")
            {
               File.Delete(path);
            }

            db = new ShopTestDataContext();
            db.Logs.DeleteAllOnSubmit(db.Logs);
            db.SubmitChanges();
        }
    }
}
