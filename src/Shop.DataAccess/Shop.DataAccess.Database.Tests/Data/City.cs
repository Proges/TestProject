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
        int ICity.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string ICity.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        int ICity.RegionID
        {
            get { return RegionID; }
            set { RegionID = value; }
        }

        IList<IAddress> ICity.Addresses
        {
            get
            {
                return Addresses.ToList<IAddress>();
            }
            set
            {
                Addresses.Clear();
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
