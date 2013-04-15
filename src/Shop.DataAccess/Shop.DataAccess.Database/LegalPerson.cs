using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class LegalPerson : ILegalPerson
    {
        int ILegalPerson.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int ILegalPerson.PersonID
        {
            get { return PersonID; }
            set { PersonID = value; }
        }

        string ILegalPerson.OrganizationName
        {
            get { return OrganizationName; }
            set { OrganizationName = value; }
        }

        string ILegalPerson.Fax
        {
            get { return Fax; }
            set { Fax = value; }
        }

        int ILegalPerson.TIN
        {
            get { return TIN; }
            set { TIN = value; }
        }

        int ILegalPerson.RCR
        {
            get { return RCR; }
            set { RCR = value; }
        }

        string ILegalPerson.LegalAddress
        {
            get { return LegalAddress; }
            set { LegalAddress = value; }
        }

        int? ILegalPerson.NCEO
        {
            get { return NCEO; }
            set { NCEO = value; }
        }

        int? ILegalPerson.UCSE
        {
            get { return UCSE; }
            set { UCSE = value; }
        }

        int? ILegalPerson.Account
        {
            get { return Account; }
            set { Account = value; }
        }

        string ILegalPerson.CorespondentAccount
        {
            get { return CorespondentAccount; }
            set { CorespondentAccount = value; }
        }

        string ILegalPerson.BIC
        {
            get { return BIC; }
            set { BIC = value; }
        }

        EntityRef<IPerson> ILegalPerson.Person
        {
            get { return new EntityRef<IPerson>(Person); }
            set { Person = (Person)value.Entity; }
        }
    }
}
