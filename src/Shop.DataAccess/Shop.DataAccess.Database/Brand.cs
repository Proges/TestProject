using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Brand : IBrand, IEntity<IBrand>
    {
        public int Identifier { get; set; }

        IList<IProduct> IBrand.Products
        {
            get
            {
                return Products.ToList<IProduct>();
            }
            set
            {
                Products = new EntitySet<Product>();
                Products.AddRange(value.Cast<Product>());
            }
        }

        IImage IBrand.Image
        {
            get { return Image; }
            set { Image = (Image)value; }
        }
    }
}
