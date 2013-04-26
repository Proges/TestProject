using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class OrdersStatus : EntityBase, IOrdersStatus
    {
        public int Identifier { get { return ID; } }

        IOrder IOrdersStatus.Order
        {
            get { return Order; }
            set { Order = (Order)value; }
        }
    }
}
