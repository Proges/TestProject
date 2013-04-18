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
        IImage IProductsImage.Image
        {
            get { return Image; }
            set { Image = (Image)value; }
        }

        IProduct IProductsImage.Product
        {
            get { return Product; }
            set { Product = (Product)value; }
        }
    }
}
