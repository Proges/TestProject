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
        IProduct Product { get; set; }
        ISupplier Supplier { get; set; }
    }
}
