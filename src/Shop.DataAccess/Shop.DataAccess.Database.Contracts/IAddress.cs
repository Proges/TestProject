using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IAddress
    {
        int ID { get; set; }
        int CityID { get; set; }
        string Street { get; set; }
        string House { get; set; }
        string Housing { get; set; }
        string Building { get; set; }
        string Porch { get; set; }
        string IntercomeCode { get; set; }
        int? Floor { get; set; }
        bool? IsOffice { get; set; }
        IList<IOrder> Orders { get; set; }
        IList<IPerson> Persons { get; set; }
        IList<ISupplier> Suppliers { get; set; }
        ICity City { get; set; }
    }
}
