using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Factory;
using Shop.Infrastructure.Logger.Contracts;
using System.Configuration;

namespace Shop.Infrastructure.Logger.Tests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void WriteLogTest()
        {
            var logger = Factory.Factory.GetComponent<ILogger>();

            logger.InfoLog("InfoTEST");
            logger.WarningLog("WarningTEST");
            logger.ErrorLog("ErrorTEST");
            logger.FatalLog("FatalTEST");
        }
    }
}
