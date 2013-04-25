using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Service.Tests.Data;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Business.Service.Tests
{
    [TestClass]
    public class ServiceTests
    {
        /*[TestMethod]
        public void ServiceTests_OrderService_AddToCart()
        {
            var product = _productRepository.GetByID(productID);
            var orderLine = Factory.GetComponent<IOrderLineBusiness>();

            var productCount = _storageRecordRepository.GetAll()
                            .Where(record => record.ProductID == productID)
                            .GroupBy(record => record.SupplierID)
                            .Select(grp => new { SupplierID = grp.Key, Count = grp.Sum(record => record.Credit) - grp.Sum(record => record.Debit) }).ToList();

            if (productCount.Sum(c => c.Count) < count)
            {
                return false;
            }

            foreach (var supplier in productCount)
            {
                var storageRecord = Factory.GetComponent<IStorageRecordBusiness>();
                storageRecord.Product = product;
                storageRecord.Date = DateTime.Now;
                storageRecord.User = order.User;
                storageRecord.Supplier = product.Suppliers.First(s => s.ID == supplier.SupplierID);

                orderLine.Product = product;
                orderLine.Count = count;
                orderLine.Supplier = storageRecord.Supplier;
                orderLine.UnitPrice = product.Price;

                if (supplier.Count >= count)
                {
                    storageRecord.Debit = count;
                    order.OrderLines.Add(orderLine);
                    _storageRecordRepository.Save((StorageRecord)storageRecord);
                    break;
                }

                count -= (int)supplier.Count;
                storageRecord.Debit = count;
                order.OrderLines.Add(orderLine);
                _storageRecordRepository.Save((StorageRecord)storageRecord);
            }
        }*/



        [TestMethod]
        public void ServiceTests_UserService_LogIn()
        {
            var userRepository = new List<TestUser>()
            {
                new TestUser(){ ID = 1, Login = "User1", Password = "psw1" },
                new TestUser(){ ID = 2, Login = "User2", Password = "psw2" },
                new TestUser(){ ID = 3, Login = "User3", Password = "psw3" },
                new TestUser(){ ID = 4, Login = "User4", Password = "psw4" },
                new TestUser(){ ID = 5, Login = "User5", Password = "psw5" },
                new TestUser(){ ID = 6, Login = "User6", Password = "psw6" }
            };

            var user = userRepository.FirstOrDefault(u => u.Login == "User3" && u.Password == "psw3");
            Assert.AreEqual(3, user.ID);
        }

        [TestMethod]
        public void ServiceTests_UserService_LogOut()
        {

        }
    }
}

