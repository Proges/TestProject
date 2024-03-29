﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface IPerson : IEntityBase, IEntity<int>
    {
        int ID { get; set; }
        string Name{ get; set; }
        string SecondName{ get; set; }
        string Patronymic{ get; set; }
        DateTime BirthDate{ get; set; }
        string Email{ get; set; }
        string Phone{ get; set; }
        int AddressID{ get; set; }
        int? SupplierID{ get; set; }
        IList<IUser> Users{ get; set; }
        IList<ILegalPerson> LegalPersons{ get; set; }
        IAddress Address{ get; set; }
        ISupplier Supplier { get; set; }
    }
}
