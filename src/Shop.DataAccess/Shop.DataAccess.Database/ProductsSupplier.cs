using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class ProductsSupplier : IProductsSupplier
    {
        IProduct IProductsSupplier.Product
        {
            get { return Product; }
            set { Product = (Product)value; }
        }

        ISupplier IProductsSupplier.Supplier
        {
            get { return Supplier; }
            set { Supplier = (Supplier)value; }
        }
    }
}
