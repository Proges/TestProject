using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Factory;
using Shop.DataAccess.Database.Contracts;
using Shop.DataAccess.ContextFactory.Contracts;
using System.Linq;

namespace Shop.DataAccess.ContextFactory.Tests
{
    [TestClass]
    public class ContextFactoryTests
    {
        IContextFactory context;
        ILog log;

        [TestInitialize]
        public void InitializeTests()
        {
            context = Factory.GetComponent<IContextFactory>();
            context.GetContext().GetTable(typeof(Log)).DeleteAllOnSubmit(context.GetContext().GetTable(typeof(Log)));
        
            log = Factory.GetComponent<ILog>();
            log.Location = "TestLocation";
            log.Message = "TestMessage";
            log.Type = "Type";
            log.Date = DateTime.Now;
        }

        [TestCleanup]
        public void CleanupTests()
        {
            context.GetContext().GetTable(typeof(Log)).DeleteAllOnSubmit(context.GetContext().GetTable(typeof(Log)));
        }

        [TestMethod]
        public void ContextFactoryTests_Commit()
        {
            Assert.AreEqual(null, context.GetContext().GetTable<Log>().FirstOrDefault());

            context.GetContext().GetTable(typeof(Log)).InsertOnSubmit(log);
            context.Commit();

            Assert.AreEqual("TestMessage", context.GetContext().GetTable<Log>().FirstOrDefault().Message);
        }

        [TestMethod]
        public void ContextFactoryTests_Rollback()
        {
            context.GetContext().GetTable(typeof(Log)).InsertOnSubmit(log);

            Assert.AreEqual(1, context.GetContext().GetChangeSet().Inserts.Count);

            context.Rollback();

            Assert.AreEqual(0, context.GetContext().GetChangeSet().Inserts.Count);            
        }
    }
}
