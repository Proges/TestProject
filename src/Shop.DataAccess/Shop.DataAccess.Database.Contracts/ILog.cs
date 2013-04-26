using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface ILog : IEntityBase, IEntity<int>
    {
        int ID { get; set; }
        DateTime Date { get; set; }
        string Type { get; set; }
        string Location { get; set; }
        string Message { get; set; }
    }
}
