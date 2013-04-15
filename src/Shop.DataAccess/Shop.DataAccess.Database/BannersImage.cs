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
        int IBannersImage.BannerID
        {
            get { return BannerID; }
            set { BannerID = value; }
        }

        IBanner IBannersImage.Banner
        {
            get { return Banner; }
            set { Banner = (Banner)value; }
        }

        int IBannersImage.ImageID
        {
            get { return ImageID; }
            set { ImageID = value; }
        }

        IImage IBannersImage.Image
        {
            get { return Image; }
            set { Image = (Image)value; }
        }
    }
}
