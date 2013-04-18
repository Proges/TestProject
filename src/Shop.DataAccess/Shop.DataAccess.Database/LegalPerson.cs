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
        IPerson ILegalPerson.Person
        {
            get { return Person; }
            set { Person = (Person)value; }
        }
    }
}
