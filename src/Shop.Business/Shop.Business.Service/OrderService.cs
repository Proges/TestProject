using Shop.Business.Data;
using Shop.Business.Data.Contracts;
using Shop.Business.Repository.Contracts;
using Shop.Business.Service.Contracts;
using Shop.DataAccess.Database;
using Shop.DataAccess.Database.Contracts;
using Shop.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Service
{
    public class OrderService : IOrderService
    {
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private IStorageRecordRepository _storageRecordRepository;


        public OrderService() : this(null, null, null)
        {

        }

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository, IStorageRecordRepository storageRecordRepository)
        {
            _productRepository = productRepository ?? Factory.GetRepository<IProductRepository>();
            _orderRepository = orderRepository ?? Factory.GetRepository<IOrderRepository>();
            _storageRecordRepository = storageRecordRepository ?? Factory.GetRepository<IStorageRecordRepository>();
        }

        public bool AddToCart(IOrderBusiness order, int productID, int count)
        {
            var product = _productRepository.GetByID(productID);
            var orderLine = Factory.GetComponent<IOrderLineBusiness>();

            var productCount = _storageRecordRepository.GetAll()
                            .Where(record => record.ProductID == productID)
                            .GroupBy(record => record.SupplierID)
                            .Select(grp => new {SupplierID = grp.Key, Count = grp.Sum(record=>record.Credit) - grp.Sum(record=>record.Debit)}).ToList();

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

            return true;               
        }

        public void RemoveFromCart(IOrderBusiness order, int productID, int count)
        {
            var product = _productRepository.GetByID(productID);
            var currOrderLines = order.OrderLines.Where(orderline => orderline.ProductID == productID);

            foreach (var orderLine in currOrderLines)
            {
                var storageRecord = Factory.GetComponent<IStorageRecordBusiness>();
                storageRecord.Product = product;
                storageRecord.Date = DateTime.Now;
                storageRecord.User = order.User;
                storageRecord.Supplier = product.Suppliers.First(s => s.ID == orderLine.SupplierID);
                _storageRecordRepository.Save((StorageRecord)storageRecord);

                if (orderLine.Count - count <= 0)
                {
                    count -= orderLine.Count;
                    order.OrderLines.Remove(orderLine);
                    continue;
                }
                orderLine.Count -= count;
                break;
            }
        }

        public IList<IOrderLineBusiness> GetCart(IOrderBusiness order)
        {
            return order.OrderLines.Cast<IOrderLineBusiness>().ToList();
        }
        
        public void MakeOrder(IOrderBusiness order)
        {
            _orderRepository.Save((Order)order);
        }
    }
}
