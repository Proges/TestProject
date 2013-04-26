using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IUser : IEntityBase, IEntity<int>
    {
        int ID { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        int RoleID { get; set; }
        int PersonID { get; set; }
        DateTime RegistrationDate { get; set; }
        IList<IFeedback> Feedbacks { get; set; }
        IList<IOrder> Orders { get; set; }
        IList<IStorageRecord> StorageRecords { get; set; }
        IPerson Person { get; set; }
    }
}
