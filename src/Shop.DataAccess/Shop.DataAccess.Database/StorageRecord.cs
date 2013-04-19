using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class StorageRecord : IStorageRecord, IEntity<IStorageRecord>
    {
        public int Identifier { get; set; }

        IProduct IStorageRecord.Product
        {
            get { return Product; }
            set { Product = (Product)value; }
        }

        IUser IStorageRecord.User
        {
            get { return User; }
            set { User = (User)value; }
        }
    }
}
