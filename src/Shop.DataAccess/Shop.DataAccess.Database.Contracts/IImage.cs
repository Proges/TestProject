using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IImage : IEntity<IImage>
    {
        int ID { get; set; }
        string Name { get; set; }
        string URL { get; set; }
        IList<IBannersImage> BannersImages { get; }
        IList<IBrand> Brands { get; set; }
        IList<IProductsImage> ProductsImages { get; }
        EntitySet<IBanner> Banners { get; }
    }
}
