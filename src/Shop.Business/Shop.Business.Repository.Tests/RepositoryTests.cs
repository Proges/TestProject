using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Moq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Collections;
using System.Linq;
using Shop.Business.Repository.Tests.Data;
using Shop.Business.Repository.Tests.Data.Contracts;

namespace Shop.Business.Repository.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        List<TestObject> table;

        [TestInitialize]
        public void Init()
        {
             table = new List<TestObject>()
                {
                    new TestObject(){ ID = 1 },
                    new TestObject(){ ID = 2 },
                    new TestObject(){ ID = 3 },
                    new TestObject(){ ID = 4 },
                    new TestObject(){ ID = 5 },
                    new TestObject(){ ID = 6 }
                };
        }

        [TestMethod]
        public void RepositoryTests_GetAll()
        {
            MappingSource mapping = new AttributeMappingSource();
            var context = new Mock<TestDataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);
            
            context.Setup(con =>con.GetTestTable<TestObject>()).Returns(() => (table.AsQueryable()));
            
            var allItems = context.Object.GetTestTable<TestObject>();
            Assert.IsNotNull(allItems);
            Assert.AreEqual(6, allItems.ToList().Count());
        }

        public void RepositoryTest_GetByID()
        {
            MappingSource mapping = new AttributeMappingSource();
            var context = new Mock<TestDataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);

            context.Setup(con => con.GetTestTable<TestObject>()).Returns(() => (table.AsQueryable()));

            var allItems = context.Object.GetTestTable<TestObject>();

            Assert.AreEqual(3, allItems.Single(entity => (int)typeof(TestObject).GetProperty("ID").GetValue(entity) == 3));
        }

        /*[TestMethod]
        public void RepositoryTest_Save()
        {
                MappingSource mapping = new AttributeMappingSource();
                var context = new Mock<TestDataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);

                context.Setup(con => con.GetTestTable<TestObject>()).Returns(() => (table.AsQueryable()));
        }

        /*
          public T Save(T entity)
        {           
            var context = _contextFactory.GetContext();
            context.GetTable<T>().InsertOnSubmit(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            var context = _contextFactory.GetContext();
            context.GetTable<T>().DeleteOnSubmit(entity);
        }
         */
    }
}
