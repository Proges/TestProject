using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class OrderLine : IOrderLine, IEntity<OrderLine>
    {
        public int Identifier { get; set; }

        IOrder IOrderLine.Order
        {
            get { return Order; }
            set { Order = (Order)value; }
        }

        IProduct IOrderLine.Product
        {
            get { return Product; }
            set { Product = (Product)value; }
        }

        ISupplier IOrderLine.Supplier
        {
            get { return Supplier; }
            set { Supplier = (Supplier)value; }
        }
    }
}
