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
        IOrder IOrdersStatus.Order
        {
            get { return Order; }
            set { Order = (Order)value; }
        }
    }
}
