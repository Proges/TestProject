using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IOrder
    {
        int ID { get; set; }
        int UserID { get; set; }
        int AddressID { get; set; }
        DateTime CreatedDate { get; set; }
        TimeSpan DeliveryTimeFrom { get; set; }
        TimeSpan DeliveryTimeTo { get; set; }
        DateTime DeliveredDate { get; set; }
        int DeliveryTypeID { get; set; }
        int PayTypeID { get; set; }
        IList<IOrderLine> OrderLines { get; set; }
        IList<IOrdersStatus> OrdersStatus { get; set; }
        IAddress Address { get; set; }
        IUser User { get; set; }
    }
}
