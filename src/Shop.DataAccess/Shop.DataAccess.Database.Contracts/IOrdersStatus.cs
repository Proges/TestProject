﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IOrdersStatus : IEntityBase, IEntity<int>
    {
        int ID { get; set; }
        int OrderID { get; set; }
        int StatusID { get; set; }
        DateTime Date { get; set; }
        IOrder Order { get; set; }
    }
}
