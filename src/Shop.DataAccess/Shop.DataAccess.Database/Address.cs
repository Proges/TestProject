using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Address : IAddress, IEntity<Address>
    {
        public int Identifier { get; set; }

        IList<IOrder> IAddress.Orders
        {
            get { return Orders.ToList<IOrder>(); }
            set
            {
                Orders = new EntitySet<Order>();
                Orders.AddRange(value.Cast<Order>());
            }
        }

        IList<IPerson> IAddress.Persons
        {
            get { return Persons.Cast<IPerson>().ToList(); }
            set
            {
                Persons = new EntitySet<Person>();
                Persons.AddRange(value.Cast<Person>());
            }
        }

        IList<ISupplier> IAddress.Suppliers
        {
            get { return Suppliers.Cast<ISupplier>().ToList(); }
            set
            {
                Suppliers = new EntitySet<Supplier>();
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
