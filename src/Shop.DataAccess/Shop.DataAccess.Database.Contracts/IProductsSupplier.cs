using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IProductsSupplier
    {
        int ProductID { get; set; }
        int SupplierID { get; set; }
        EntityRef<IProduct> Product { get; set; }
        EntityRef<ISupplier> Supplier { get; set; }
    }
}
