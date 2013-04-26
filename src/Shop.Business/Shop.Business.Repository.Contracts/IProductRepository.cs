using Shop.Business.Data.Contracts;
using Shop.DataAccess.Database;
using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Repository.Contracts
{
    public interface IProductRepository : IRepository<IProductBusiness>
    {
        IQueryable<IProductBusiness> SearchProducts(string search);
    }
}
