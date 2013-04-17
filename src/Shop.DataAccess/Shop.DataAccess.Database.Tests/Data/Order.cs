﻿using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class Order : IOrder
    {
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
                OrdersStatus = new EntitySet<Tests.OrdersStatus>();
                OrdersStatus.AddRange(value.Cast<OrdersStatus>());
            }
        }

        EntityRef<IAddress> IOrder.Address
        {
            get { return new EntityRef<IAddress>(Address); }
            set { Address = (Address)value.Entity; }
        }

        EntityRef<IUser> IOrder.User
        {
            get { return new EntityRef<IUser>(User); }
            set { User = (User)value.Entity; }
        }
    }
}
