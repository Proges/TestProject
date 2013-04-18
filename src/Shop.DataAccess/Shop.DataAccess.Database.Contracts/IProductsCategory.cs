using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IProductsCategory
    {
        int ProductID { get; set; }
        IProduct Product { get; set; }

        int CategoryID { get; set; }
        ICategory Category { get; set; }
    }
}
