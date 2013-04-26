using Shop.Business.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Service.Contracts
{
    public interface IUserService
    {
        IUserBusiness LogIn(string login, string password);
        IUserBusiness LogOut();
        IUserBusiness Registration(IUserBusiness user, int roleID);
        bool SendPassword(string email);
    }
}
