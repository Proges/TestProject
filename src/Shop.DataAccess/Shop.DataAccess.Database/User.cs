using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class User : IUser
    {
        IList<IFeedback> IUser.Feedbacks
        {
            get
            {
                return Feedbacks.Cast<IFeedback>().ToList();
            }
            set
            {
                Feedbacks = new EntitySet<Feedback>();
                Feedbacks.AddRange(value.Cast<Feedback>());
            }
        }

        IList<IOrder> IUser.Orders
        {
            get
            {
                return Orders.ToList<IOrder>();
            }
            set
            {
                Orders = new EntitySet<Order>();
                Orders.AddRange(value.Cast<Order>());
            }
        }

        IList<IStorageRecord> IUser.StorageRecords
        {
            get
            {
                return StorageRecords.Cast<IStorageRecord>().ToList();
            }
            set
            {
                StorageRecords = new EntitySet<StorageRecord>();
                StorageRecords.AddRange(value.Cast<StorageRecord>());
            }
        }

        IPerson IUser.Person
        {
            get { return Person; }
            set { Person = (Person)value; }
        }
    }
}
