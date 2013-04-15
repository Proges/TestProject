﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IOrderLine
    {
        int ID { get; set; }
        int ProductID { get; set; }
        int OrderID { get; set; }
        int Count { get; set; }
        int UnitPrice { get; set; }
        int SupplierID { get; set; }
        EntityRef<IOrder> Order { get; set; }
        EntityRef<IProduct> Product { get; set; }
        EntityRef<ISupplier> Supplier { get; set; }
    }
}