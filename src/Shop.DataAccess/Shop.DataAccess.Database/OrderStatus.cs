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
        int IOrdersStatus.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int IOrdersStatus.OrderID
        {
            get { return OrderID; }
            set { OrderID = value; }
        }

        int IOrdersStatus.StatusID
        {
            get { return StatusID; }
            set { StatusID = value; }
        }

        DateTime IOrdersStatus.Date
        {
            get { return Date; }
            set { Date = value; }
        }

        EntityRef<IOrder> IOrdersStatus.Order
        {
            get { return new EntityRef<IOrder>(); }
            set { Order = (Order)value.Entity; }
        }
    }
}
