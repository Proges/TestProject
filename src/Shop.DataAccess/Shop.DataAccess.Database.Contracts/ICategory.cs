using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface ICategory : IEntityBase, IEntity<int>
    {
        int ID { get; set; }
        int? ParentCategoryID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IList<ICategory>  Categories { get; set; }
        IList<IProductsCategory> ProductsCategories { get; }
        ICategory ParentCategory { get; set; }
    }
}
