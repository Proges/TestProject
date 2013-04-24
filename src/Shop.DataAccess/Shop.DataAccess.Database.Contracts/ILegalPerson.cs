using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Contracts
{
    public interface ILegalPerson : IEntity<ILegalPerson>
    {
        int ID { get; set; }
        int PersonID { get; set; }
        string OrganizationName { get; set; }
        string Fax { get; set; }
        int TIN { get; set; }
        int RCR { get; set; }
        string LegalAddress { get; set; }
        int? NCEO { get; set; }
        int? UCSE { get; set; }
        int? Account { get; set; }
        string CorespondentAccount { get; set; }
        string BIC { get; set; }
        IPerson Person { get; set; }
    }
}
