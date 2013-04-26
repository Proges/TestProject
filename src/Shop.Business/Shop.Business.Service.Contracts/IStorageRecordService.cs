using Shop.Business.Data.Contracts;
using Shop.Business.Data.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Service.Contracts
{
    public interface IStorageRecordService
    {
        IQueryable<SuppliersProductCount> GetSuppliersProductCount(IProductBusiness product);
    }
}
