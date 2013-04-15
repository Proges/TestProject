using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Address : IAddress
    {
        int IAddress.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int IAddress.CityID
        {
            get { return CityID; }
            set { CityID = value; }
        }

        string IAddress.Street
        {
            get { return Street; }
            set { Street = value; }
        }

        string IAddress.House
        {
            get { return House; }
            set { House = value; }
        }

        string IAddress.Housing
        {
            get { return Housing; }
            set { Housing = value; }
        }

        string IAddress.Building
        {
            get { return Building; }
            set { Building = value; }
        }

        string IAddress.Porch
        {
            get { return Porch; }
            set { Porch = value; }
        }

        string IAddress.IntercomeCode
        {
            get { return IntercomeCode; }
            set { IntercomeCode = value; }
        }

        int? IAddress.Floor
        {
            get { return Floor; }
            set { Floor = value; }
        }

        bool? IAddress.IsOffice
        {
            get { return IsOffice; }
            set { IsOffice = value; }
        }

        IList<IOrder> IAddress.Orders
        {
            get { return Orders.Cast<IOrder>().ToList(); }
            set
            {
                Orders.Clear();
                Orders.AddRange(value.Cast<Order>());
            }
        }

        IList<IPerson> IAddress.Persons
        {
            get { return Persons.Cast<IPerson>().ToList(); }
            set
            {
                Persons.Clear();
                Persons.AddRange(value.Cast<Person>());
            }
        }

        IList<ISupplier> IAddress.Suppliers
        {
            get { return Suppliers.Cast<ISupplier>().ToList(); }
            set
            {
                Suppliers.Clear();
                Suppliers.AddRange(value.Cast<Supplier>());
            }
        }

        ICity IAddress.City
        {
            get { return City; }
            set { City = (City)value; }
        }
    }
}
