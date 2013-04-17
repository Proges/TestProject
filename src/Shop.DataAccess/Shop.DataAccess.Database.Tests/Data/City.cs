using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class City : ICity
    {
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

        EntityRef<IRegion> ICity.Region
        {
            get { return new EntityRef<IRegion>(Region); }
            set { Region = (Region)value.Entity; }
        }
    }
}
