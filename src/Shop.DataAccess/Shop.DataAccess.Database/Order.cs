using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Order : IOrder
    {
        int IOrder.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int IOrder.UserID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        int IOrder.AddressID
        {
            get { return AddressID; }
            set { AddressID = value; }
        }

        DateTime IOrder.CreatedDate
        {
            get { return CreatedDate; }
            set { CreatedDate = value; }
        }

        TimeSpan IOrder.DeliveryTimeFrom
        {
            get { return DeliveryTimeFrom; }
            set { DeliveryTimeFrom = value; }
        }

        TimeSpan IOrder.DeliveryTimeTo
        {
            get { return DeliveryTimeTo; }
            set { DeliveryTimeTo = value; }
        }

        DateTime IOrder.DeliveredDate
        {
            get { return DeliveredDate; }
            set { DeliveredDate = value; }
        }

        int IOrder.DeliveryTypeID
        {
            get { return DeliveryTypeID; }
            set { DeliveryTypeID = value; }
        }

        int IOrder.PayTypeID
        {
            get { return PayTypeID; }
            set { PayTypeID = value; }
        }

        IList<IOrderLine> IOrder.OrderLines
        {
            get
            {
                return OrderLines.ToList<IOrderLine>();
            }
            set
            {
                OrderLines.Clear();
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
                OrdersStatus.Clear();
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
