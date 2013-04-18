using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IProductsImage
    {
        int ProductID { get; set; }
        int ImageID { get; set; }
        IImage Image { get; set; }
        IProduct Product { get; set; }
    }
}
