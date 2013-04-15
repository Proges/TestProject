using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IRegion
    {
        int ID { get; set; }
        string Name { get; set; }
        IList<ICity> Cities { get; set; }
    }
}
