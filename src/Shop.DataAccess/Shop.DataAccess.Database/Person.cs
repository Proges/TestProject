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
        int IPerson.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string IPerson.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        string IPerson.SecondName
        {
            get { return SecondName; }
            set { SecondName = value; }
        }

        string IPerson.Patronymic
        {
            get { return Patronymic; }
            set { Patronymic = value; }
        }

        DateTime IPerson.BirthDate
        {
            get { return BirthDate; }
            set { BirthDate = value; }
        }

        string IPerson.Email
        {
            get { return Email; }
            set { Email = value; }
        }

        string IPerson.Phone
        {
            get { return Phone; }
            set { Phone = value; }
        }

        int IPerson.AddressID
        {
            get { return AddressID; }
            set { AddressID = value; }
        }

        int? IPerson.SupplierID
        {
            get { return SupplierID; }
            set { SupplierID = value; }
        }

        IList<IUser> IPerson.Users
        {
            get
            {
                return Users.ToList<IUser>();
            }
            set
            {
                Users.Clear();
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
                LegalPersons.Clear();
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
