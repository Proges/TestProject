using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class OrdersStatus : IOrdersStatus
    {
        EntityRef<IOrder> IOrdersStatus.Order
        {
            get { return new EntityRef<IOrder>(); }
            set { Order = (Order)value.Entity; }
        }
    }
}
