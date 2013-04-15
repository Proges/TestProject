using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface ISupplier
    {
        int ID { get; set; }
        string Name { get; set; }
        int AddressID { get; set; }
        IList<IBanner> Banners { get; set; }
        IList<IOrderLine> OrderLines { get; set; }
        IList<IPerson> Persons { get; set; }
        IList<IProductsSupplier> ProductsSuppliers { get; }
        EntityRef<IAddress> Address { get; set; }
    }
}
