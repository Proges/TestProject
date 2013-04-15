using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IProduct
    {
         int ID{get;set;}
         string Name { get; set; }
         int Price { get; set; }
         int BrandID { get; set; }
         IList<IOrderLine> OrderLines { get; set; }
         IList<IProductsCategory> ProductsCategories { get; }
         IList<IProductsImage> ProductsImages { get; }
         IList<IProductsSupplier> ProductsSuppliers { get; }
         IList<IStorageRecord> StorageRecords { get; set; }
         EntityRef<IBrand> Brand { get; set; }
    }
}
