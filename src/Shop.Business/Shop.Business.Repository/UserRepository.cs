using Shop.Business.Repository.Contracts;
using Shop.DataAccess.Database;
using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

    }
}
