using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Shop.Infrastructure.Factory.Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void FactoryTests_GetComponent()
        {            
            var testObject = Factory.GetComponent<ITestComponent>();
            Assert.AreEqual("TestObject", testObject.Name);      
        }

        [TestMethod]
        public void FactoryTests_GetRepository()
        {
            var testRepository = Factory.GetRepository<ITestRepository>();
            Assert.AreEqual("TestRepository", testRepository.Name);
        }

        [TestMethod]
        public void FactoryTests_GetManager()
        {
            var testManager = Factory.GetManager<ITestManager>();
            Assert.AreEqual("TestManager", testManager.Name);
        }

        [TestMethod]
        public void FactoryTests_Another_GetManager()
        {
            var testManager = Factory.GetManager<ITestManager>();
            Assert.AreNotEqual("AnotherTestManager", testManager.Name);
        }

        [TestMethod]
        public void FactoryTests_GetService()
        {
            var testService = Factory.GetService<ITestService>();
            Assert.AreEqual("TestService", testService.Name);
        }
    }
}
