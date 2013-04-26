using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IBrand : IEntityBase, IEntity<int>
    {
        int ID { get; set; }
        string Name { get; set; }
        int? LogoID { get; set; }
        IList<IProduct> Products { get; set; }
        IImage Image { get; set; }
    }
}
