using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class ProductsCategory : IProductsCategory
    {
        IProduct IProductsCategory.Product
        {
            get { return Product; }
            set { Product = (Product)value; }
        }

        int IProductsCategory.CategoryID
        {
            get { return CategoryID; }
            set { CategoryID = value; }
        }
        ICategory IProductsCategory.Category
        {
            get { return Category; }
            set { Category = (Category)value; }
        }
    }
}
