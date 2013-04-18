using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IBanner
    {
        int ID { get; set; }
        string Name { get; set; }
        int SupplierID { get; set; }
        IList<IBannersImage> BannersImages { get; }
        ISupplier Supplier { get; set; }
        EntitySet<IImage> Images { get; }
    }
}
