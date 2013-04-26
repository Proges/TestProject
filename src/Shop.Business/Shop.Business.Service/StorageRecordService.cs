using Shop.Business.Data.Contracts;
using Shop.Business.Data.Structs;
using Shop.Business.Repository.Contracts;
using Shop.Business.Service.Contracts;
using Shop.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Business.Service
{
    public class StorageRecordService : IStorageRecordService
    {
        private IStorageRecordRepository _storageRecordRepository;

        public StorageRecordService()
        {
        }

        public StorageRecordService(IStorageRecordRepository storageRecordRepository)
        {
            _storageRecordRepository = storageRecordRepository ?? Factory.GetRepository<IStorageRecordRepository>();
        }

        public IQueryable<SuppliersProductCount> GetSuppliersProductCount(IProductBusiness product)
        {
            return _storageRecordRepository.GetAll()
                                .Where(record => record.ProductID == product.ID)
                                .GroupBy(record => record.Supplier.ID)
                                .Select(grp => new SuppliersProductCount() { SupplierID = grp.Key, ProductCount = grp.Sum(record => record.Credit) - grp.Sum(record => record.Debit) });
        }
    }
}
