using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class Brand : IBrand
    {
        int IBrand.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string IBrand.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        int? IBrand.LogoID
        {
            get { return LogoID; }
            set { LogoID = value; }
        }

        IList<IProduct> IBrand.Products
        {
            get
            {
                return Products.ToList<IProduct>();
            }
            set
            {
                Products.Clear();
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
