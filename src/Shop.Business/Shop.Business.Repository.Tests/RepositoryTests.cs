using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Moq;
using System.Data.Linq;
using System.Collections.Generic;

namespace Shop.Business.Repository.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        /*T GetAll<T>() where T:class
        {
            var list = new List<TestObject>{
                  new TestObject(){ ID = 1},
                  new TestObject(){ ID = 2},
                  new TestObject(){ ID = 3}
            };
            var context = new Mock<DataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);
           
        }
         
        [TestMethod]
        public void RepositoryTests_GetAll()
        {

        }

        [TestMethod]
        public void RepositoryTests_GetByID()
        {
            var ID = 1;

            if (ID <= 0)
            {
                return null;
            }

            var context = new Mock<DataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);
            return context.GetTable<T>().Single(entity => (int)typeof(T).GetProperty("ID").GetValue(entity) == ID);
        }

        [TestMethod]
        public void RepositoryTests_Save()
        {
            var context = new Mock<DataContext>(ConfigurationManager.ConnectionStrings["ShopTestConnectionString"].ConnectionString, mapping);
            context.GetTable<T>().InsertOnSubmit(entity);
            return entity;
        }

        [TestMethod]
        public void RepositoryTests_Delete()
        {
            var context = _contextFactory.GetContext();
            context.GetTable<T>().DeleteOnSubmit(entity);
        }*/
    }
}
