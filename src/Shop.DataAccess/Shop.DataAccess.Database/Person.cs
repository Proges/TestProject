using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Person : IPerson
    {
        IList<IUser> IPerson.Users
        {
            get
            {
                return Users.ToList<IUser>();
            }
            set
            {
                Users = new EntitySet<User>();
                Users.AddRange(value.Cast<User>());
            }
        }

        IList<ILegalPerson> IPerson.LegalPersons
        {
            get
            {
                return LegalPersons.ToList<ILegalPerson>();
            }
            set
            {
                LegalPersons = new EntitySet<LegalPerson>();
                LegalPersons.AddRange(value.Cast<LegalPerson>());
            }
        }

        EntityRef<IAddress> IPerson.Address
        {
            get { return new EntityRef<IAddress>(Address); }
            set { Address = (Address)value.Entity; }
        }

        EntityRef<ISupplier> IPerson.Supplier
        {
            get { return new EntityRef<ISupplier>(Supplier); }
            set { Supplier = (Supplier)value.Entity; }
        }
    }
}
