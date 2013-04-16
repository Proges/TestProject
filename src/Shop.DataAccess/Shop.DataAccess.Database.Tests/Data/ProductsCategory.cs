using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class ProductsCategory : IProductsCategory
    {
        int IProductsCategory.ProductID
        {
            get { return ProductID; }
            set { ProductID = value; }
        }
        EntityRef<IProduct> IProductsCategory.Product
        {
            get { return new EntityRef<IProduct>(Product); }
            set { Product = (Product)value.Entity; }
        }

        int IProductsCategory.CategoryID
        {
            get { return CategoryID; }
            set { CategoryID = value; }
        }
        EntityRef<ICategory> IProductsCategory.Category
        {
            get { return new EntityRef<ICategory>(Category); }
            set { Category = (Category)value.Entity; }
        }
    }
}
