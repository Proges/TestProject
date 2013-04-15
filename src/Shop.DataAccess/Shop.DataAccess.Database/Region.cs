using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Region : IRegion
    {
        int IRegion.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string IRegion.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        IList<ICity> IRegion.Cities
        {
            get
            {
                return Cities.ToList<ICity>();
            }
            set
            {
                Cities.Clear();
                Cities.AddRange(value.Cast<City>());
            }
        }
    }
}
