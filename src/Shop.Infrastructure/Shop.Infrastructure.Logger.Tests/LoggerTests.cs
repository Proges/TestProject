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
        string infoLog = "InfoTEST";
        string warningLog = "WarningTEST";
        string errorLog = "ErrorTEST";
        string fatalLog = "FatalTEST";
        string debugLog = "DebugTest";
        string exceptionLog = new InvalidCastException().Message;

        [TestInitialize]
        public void InitTests()
        {
            var logger = Factory.Factory.GetComponent<ILogger>();
            log4net.Config.XmlConfigurator.Configure();

            logger.InfoLog(infoLog);
            logger.WarningLog(warningLog);
            logger.ErrorLog(errorLog);
            logger.FatalLog(fatalLog);
            logger.DebugLog(debugLog);
            logger.ExceptionLog(new InvalidCastException());
        }

        [TestMethod]
        public void WriteLogTest()
        {
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
            }
            Assert.IsTrue(logString.Contains(infoLog));
            Assert.IsTrue(logString.Contains(warningLog));
            Assert.IsTrue(logString.Contains(errorLog));
            Assert.IsTrue(logString.Contains(fatalLog));
            Assert.IsTrue(logString.Contains(debugLog));
            Assert.IsTrue(logString.Contains(exceptionLog));
        }

        [TestMethod]
        public void DatabaseLogTest()
        {
            string conString = "Server=(local); database=ShopTest; Trusted_Connection=Yes;Integrated Security=true";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string logMessages = "";
                string sql = "SELECT [Message] FROM [ShopTest].[dbo].[Logs]";
                SqlCommand cmd = new SqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    logMessages += reader[0];
                }

                reader.Close();

                Assert.IsTrue(logMessages.Contains(infoLog));
                Assert.IsTrue(logMessages.Contains(warningLog));
                Assert.IsTrue(logMessages.Contains(errorLog));
                Assert.IsTrue(logMessages.Contains(fatalLog));
                Assert.IsTrue(logMessages.Contains(debugLog));
                Assert.IsTrue(logMessages.Contains(exceptionLog));

                sql = @"DELETE FROM [ShopTest].[dbo].[Logs];";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();               
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
