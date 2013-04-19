using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Order : IOrder, IEntity<IOrder>
    {
        public int Identifier { get; set; }

        IList<IOrderLine> IOrder.OrderLines
        {
            get
            {
                return OrderLines.ToList<IOrderLine>();
            }
            set
            {
                OrderLines = new EntitySet<OrderLine>();
                OrderLines.AddRange(value.Cast<OrderLine>());
            }
        }

        IList<IOrdersStatus> IOrder.OrdersStatus
        {
            get
            {
                return OrdersStatus.ToList<IOrdersStatus>();
            }
            set
            {                
                OrdersStatus = new EntitySet<OrdersStatus>();
                OrdersStatus.AddRange(value.Cast<OrdersStatus>());
            }
        }

        IAddress IOrder.Address
        {
            get { return Address; }
            set { Address = (Address)value; }
        }

        IUser IOrder.User
        {
            get { return User; }
            set { User = (User)value; }
        }
    }
}
