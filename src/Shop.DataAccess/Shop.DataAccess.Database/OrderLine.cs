using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class OrderLine : IOrderLine
    {
        EntityRef<IOrder> IOrderLine.Order
        {
            get { return new EntityRef<IOrder>(Order); }
            set { Order = (Order)value.Entity; }
        }

        EntityRef<IProduct> IOrderLine.Product
        {
            get { return new EntityRef<IProduct>(Product); }
            set { Product = (Product)value.Entity; }
        }

        EntityRef<ISupplier> IOrderLine.Supplier
        {
            get { return new EntityRef<ISupplier>(Supplier); }
            set { Supplier = (Supplier)value.Entity; }
        }
    }
}
