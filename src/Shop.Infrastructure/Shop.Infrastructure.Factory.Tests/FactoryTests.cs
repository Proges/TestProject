using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shop.Infrastructure.Factory.Tests
{

     interface ITestObject
    {
        string Name { get; }
    }

     class TestObject : ITestObject
    {
        public string Name
        {
            get { return "TestObject"; }
        }
    }


     interface ITestRepository
    {
        string Name { get; }
    }


    class TestRepository : ITestRepository
    {
        string ITestRepository.Name
        {
            get { return "TestRepository"; }
        }
    }


    interface ITestManager
    {
        string Name { get; }
    }

    class TestManager : ITestManager
    {
        string ITestManager.Name
        {
            get { return "TestManager"; }
        }
    }

    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void ContainerAccessTest()
        {
            var testObject = Factory.GetComponent<ITestObject>();
            var testRepository = Factory.GetRepository<ITestRepository>();
            var testManager = Factory.GetManager<ITestManager>();

            Assert.AreEqual("TestObject", testObject.Name);
            Assert.AreEqual("TestRepository", testRepository.Name);
            Assert.AreEqual("TestManager", testManager.Name);
        }
    }
}
