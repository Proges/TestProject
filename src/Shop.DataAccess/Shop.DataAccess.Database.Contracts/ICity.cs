using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface ICity
    {
        int ID { get; set; }
        string Name { get; set; }
        int RegionID { get; set; }
        IList<IAddress> Addresses { get; set; }
        IRegion Region { get; set; }
    }
}
