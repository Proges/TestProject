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
