using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class City : ICity, IEntity<City>
    {
        public int Identifier { get; set; }

        IList<IAddress> ICity.Addresses
        {
            get
            {
                return Addresses.ToList<IAddress>();
            }
            set
            {
                Addresses = new EntitySet<Address>();
                Addresses.AddRange(value.Cast<Address>());
            }
        }

        IRegion ICity.Region
        {
            get { return Region; }
            set { Region = (Region)value; }
        }
    }
}
