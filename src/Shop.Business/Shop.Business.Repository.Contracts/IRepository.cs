using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Repository.Contracts
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetByID(int ID);
        T Save(T entity);
        void Delete(T entity);
    }
}
