using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class ProductsImage : IProductsImage
    {
        EntityRef<IImage> IProductsImage.Image
        {
            get { return new EntityRef<IImage>(Image); }
            set { Image = (Image)value.Entity; }
        }

        EntityRef<IProduct> IProductsImage.Product
        {
            get { return new EntityRef<IProduct>(Product); }
            set { Product = (Product)value.Entity; }
        }
    }
}
