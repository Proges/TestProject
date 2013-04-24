using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Log : ILog, IEntity<Log>
    {
        public int Identifier { get; set; }
    }
}
