using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IStorageRecord : IEntity<IStorageRecord>
    {
        int ID { get; set; }
        int ProductID { get; set; }
        int UserID { get; set; }
        int? Debit { get; set; }
        int? Credit { get; set; }
        DateTime Date { get; set; }
        IProduct Product { get; set; }
        IUser User { get; set; }
        ISupplier Supplier { get; set; }
    }
}
