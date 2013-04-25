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
        
        public void MakeOrder(IOrderBusiness order, ICart cart)
        {
            if (order == null)
            {
                return;
            }

            foreach (var cartProduct in cart.GetCart())
            {
                var count = cartProduct.Value;
                var product = _productRepository.GetByID(cartProduct.Key);
                var orderLine = Factory.GetComponent<IOrderLineBusiness>();

                var productSuppliers = _storageRecordRepository.GetAll()
                                .Where(record => record.ProductID == cartProduct.Key)
                                .GroupBy(record => record.Supplier.ID)
                                .Select(grp => new { SupplierID = grp.Key, Count = grp.Sum(record => record.Credit) - grp.Sum(record => record.Debit) }).ToList();



                foreach (var supplier in productSuppliers)
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
                        _storageRecordRepository.Save((StorageRecordBusiness)storageRecord);
                        break;
                    }

                    count -= (int)supplier.Count;
                    storageRecord.Debit = count;
                    order.OrderLines.Add(orderLine);
                    _storageRecordRepository.Save((StorageRecordBusiness)storageRecord);
                }
            }

            _orderRepository.Save(order);
        }


        public void AbortOrder(IOrderBusiness order)
        {
            if (order == null)
            {
                return;
            }

            _orderRepository.Delete(order);
           
            var currOrderLines = order.OrderLines.Where(orderline => orderline.OrderID == order.ID);

            foreach (var orderLine in currOrderLines)
            {
                var storageRecord = Factory.GetComponent<IStorageRecordBusiness>();
                storageRecord.Product = orderLine.Product;
                storageRecord.Date = DateTime.Now;
                storageRecord.User = order.User;
                storageRecord.Supplier = orderLine.Supplier;
                storageRecord.Debit = orderLine.Count;
                _storageRecordRepository.Save((StorageRecordBusiness)storageRecord);               
            }
        }        
    }
}
