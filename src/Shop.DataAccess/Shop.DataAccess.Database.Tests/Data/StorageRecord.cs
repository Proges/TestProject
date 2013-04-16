using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class StorageRecord : IStorageRecord
    {
        int IStorageRecord.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int IStorageRecord.ProductID
        {
            get { return ProductID; }
            set { ProductID = value; }
        }

        int IStorageRecord.UserID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        int? IStorageRecord.Debit
        {
            get { return Debit; }
            set { Debit = value; }
        }

        int? IStorageRecord.Credit
        {
            get { return Credit; }
            set { Credit = value; }
        }

        DateTime IStorageRecord.Date
        {
            get { return Date; }
            set { Date = value; }
        }

        EntityRef<IProduct> IStorageRecord.Product
        {
            get { return new EntityRef<IProduct>(Product); }
            set { Product = (Product)value.Entity; }
        }

        EntityRef<IUser> IStorageRecord.User
        {
            get { return new EntityRef<IUser>(User); }
            set { User = (User)value.Entity; }
        }
    }
}
