using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class User : IUser
    {
        int IUser.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string IUser.Login
        {
            get { return Login; }
            set { Login = value; }
        }

        string IUser.Password
        {
            get { return Password; }
            set { Password = value; }
        }

        int IUser.RoleID
        {
            get { return RoleID; }
            set { RoleID = value; }
        }

        int IUser.PersonID
        {
            get { return PersonID; }
            set { PersonID = value; }
        }

        DateTime IUser.RegistrationDate
        {
            get { return RegistrationDate; }
            set { RegistrationDate = value; }
        }

        IList<IFeedback> IUser.Feedbacks
        {
            get
            {
                return Feedbacks.Cast<IFeedback>().ToList();
            }
            set
            {
                Feedbacks.Clear();
                Feedbacks.AddRange(value.Cast<Feedback>());
            }
        }

        IList<IOrder> IUser.Orders
        {
            get
            {
                return Orders.Cast<IOrder>().ToList();
            }
            set
            {
                Orders.Clear();
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
                StorageRecords.Clear();
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
