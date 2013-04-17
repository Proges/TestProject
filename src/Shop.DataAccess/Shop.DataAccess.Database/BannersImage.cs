using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class BannersImage : IBannersImage
    {
        IBanner IBannersImage.Banner
        {
            get { return Banner; }
            set { Banner = (Banner)value; }
        }             

        IImage IBannersImage.Image
        {
            get { return Image; }
            set { Image = (Image)value; }
        }
    }
}
