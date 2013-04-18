using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Factory;
using Shop.DataAccess.Database.Contracts;
using Shop.DataAccess.ContextFactory.Contracts;
using System.Linq;
using Moq;
using System.Data.Linq;
using System.Configuration;
using System.Data.Linq.Mapping;

namespace Shop.DataAccess.ContextFactory.Tests
{
    [TestClass]
    public class ContextFactoryTests
    {       
        [TestMethod]
        public void ContextFactoryTests_Commit()
        {
            var contextFactory = new Mock<IContextFactory>();

            contextFactory.Setup(con => con.Commit()).Verifiable();

            contextFactory.Object.Commit();
            contextFactory.Verify(con => con.Commit());
        }

        [TestMethod]
        public void ContextFactoryTests_Rollback()
        {
            var contextFactory = new Mock<IContextFactory>();

            contextFactory.Setup(con => con.Rollback()).Callback(() => contextFactory = null);

            contextFactory.Object.Rollback();
            Assert.AreEqual(null, contextFactory);
        }

        [TestMethod]
        public void ContextFactory_GetContext()
        {
            var contextFactory = new Mock<IContextFactory>();
            MappingSource mapping = new AttributeMappingSource();

            contextFactory.Setup(con => con.GetContext()).Returns(new DataContext(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping));

            var context = contextFactory.Object.GetContext();
            Assert.IsNotNull(context);
        }
    }
}
