using Shop.Business.Data;
using Shop.Business.Data.Contracts;
using Shop.Business.Repository.Contracts;
using Shop.Business.Service.Contracts;
using Shop.DataAccess.ContextFactory;
using Shop.DataAccess.ContextFactory.Contracts;
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
        private IStorageRecordService _storageRecordService;
        private IStorageRecordRepository _storageRecordRepository;
        private IContextFactory _contextFactory;

        public OrderService() : this(null, null, null, null, null)
        {

        }

        public OrderService(IProductRepository productRepository,
            IOrderRepository orderRepository, 
            IStorageRecordService storageRecordService, 
            IStorageRecordRepository storageRecordRepository, 
            IContextFactory contextFactory)
        {
            _productRepository = productRepository ?? Factory.GetRepository<IProductRepository>();
            _orderRepository = orderRepository ?? Factory.GetRepository<IOrderRepository>();
            _storageRecordService = storageRecordService ?? Factory.GetService<IStorageRecordService>();
            _storageRecordRepository = storageRecordRepository ?? Factory.GetRepository<IStorageRecordRepository>();
            _contextFactory = contextFactory ?? DbSession.Instance.ContextFactory;
        }        
        
        public void MakeOrder(IOrderBusiness order, ICart cart)
        {
            var tran = _contextFactory.GetContext().Connection.BeginTransaction(System.Data.IsolationLevel.Serializable);

            if (order == null)
            {
                return;
            }

            foreach (var cartProduct in cart.GetCart())
            {
                var count = cartProduct.Value;
                var product = _productRepository.GetByID(cartProduct.Key.ID);
                var orderLine = Factory.GetComponent<IOrderLineBusiness>();

                var productSuppliers = _storageRecordService.GetSuppliersProductCount(cartProduct.Key);
                
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

                    if (supplier.ProductCount >= count)
                    {
                        storageRecord.Debit = count;
                        order.OrderLines.Add(orderLine);
                        _storageRecordRepository.Save((StorageRecordBusiness)storageRecord);
                        break;
                    }

                    count -= (int)supplier.ProductCount;
                    storageRecord.Debit = count;
                    order.OrderLines.Add(orderLine);
                    _storageRecordRepository.Save((StorageRecordBusiness)storageRecord);
                }
            }

            _orderRepository.Save(order);
            tran.Commit();
        }


        public void AbortOrder(IOrderBusiness order)
        {
            if (order == null)
            {
                return;
            }            
           
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
            _orderRepository.Delete(order);
        }        
    }
}
