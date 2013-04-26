using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class LegalPerson : EntityBase, ILegalPerson
    {
        public int Identifier { get { return ID; } }

        IPerson ILegalPerson.Person
        {
            get { return Person; }
            set { Person = (Person)value; }
        }
    }
}
