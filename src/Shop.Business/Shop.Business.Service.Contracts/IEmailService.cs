using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Service.Contracts
{
    public interface IEmailService
    {
        void SendEmail(string userEmail, string title, string body);
    }
}
