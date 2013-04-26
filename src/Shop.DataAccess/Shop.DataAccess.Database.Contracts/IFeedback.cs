using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IFeedback : IEntityBase, IEntity<int>
    {
        int ID { get; set; }
        int UserID { get; set; }
        string Topic { get; set; }
        string Text { get; set; }
        DateTime Date { get; set; }
        IUser User { get; set; }
    }
}
