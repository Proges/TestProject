using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IBannersImage
    {
        int BannerID { get; set; }
        IBanner Banner { get; set; }

        int ImageID { get; set; }
        IImage Image { get; set; }
    }
}
