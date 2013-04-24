using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Enumerators
{
    public enum OrderStatus
    {
        Start = 1, 
        Running = 2, 
        Cancel = 3,
        Complite = 4
    }
}
