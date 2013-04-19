using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Region : IRegion, IEntity<IRegion>
    {
        public int Identifier { get; set; }

        IList<ICity> IRegion.Cities
        {
            get
            {
                return Cities.ToList<ICity>();
            }
            set
            {
                Cities = new EntitySet<City>();
                Cities.AddRange(value.Cast<City>());
            }
        }
    }
}
