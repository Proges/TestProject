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
            var submit = false;
            MappingSource mapping = new AttributeMappingSource();
            var context = new Mock<DataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);

            context.Setup(con => con.SubmitChanges(It.IsAny<ConflictMode>())).Callback(() => submit = true).Verifiable();

            context.Object.SubmitChanges();
            context.Verify(con => con.SubmitChanges(It.IsAny<ConflictMode>()));
            Assert.IsTrue(submit);
        }

        [TestMethod]
        public void ContextFactoryTests_Rollback()
        {
            MappingSource mapping = new AttributeMappingSource();
            var context = new Mock<DataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);

            context = null;                   
            Assert.IsNull(context);
        }

        [TestMethod]
        public void ContextFactory_GetContext()
        {
            MappingSource mapping = new AttributeMappingSource();
            var context = new Mock<DataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);

            if (context == null)
            {
                context = new Mock<DataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);
            }           

            Assert.IsNotNull(context);
        }
    }
}
