using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class ProductsSupplier : IProductsSupplier
    {
        int IProductsSupplier.ProductID
        {
            get { return ProductID; }
            set { ProductID = value; }
        }

        int IProductsSupplier.SupplierID
        {
            get { return SupplierID; }
            set { SupplierID = value; }
        }

        EntityRef<IProduct> IProductsSupplier.Product
        {
            get { return new EntityRef<IProduct>(Product); }
            set { Product = (Product)value.Entity; }
        }

        EntityRef<ISupplier> IProductsSupplier.Supplier
        {
            get { return new EntityRef<ISupplier>(Supplier); }
            set { Supplier = (Supplier)value.Entity; }
        }
    }
}
