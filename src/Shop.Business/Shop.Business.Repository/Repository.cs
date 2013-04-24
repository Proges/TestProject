using Shop.Business.Repository.Contracts;
using Shop.DataAccess.ContextFactory;
using Shop.DataAccess.ContextFactory.Contracts;
using Shop.DataAccess.Database;
using Shop.DataAccess.Database.Contracts;
using Shop.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Repository
{
    public class Repository<T> : IRepository<T> 
        where T: class, IEntity<T>
    {
        private IContextFactory _contextFactory;

        
        public Repository()
        {
            _contextFactory = Factory.GetComponent<IContextFactory>();
        }
        
        public IQueryable<T> GetAll()
        {
            var context = _contextFactory.GetContext();
            return context.GetTable<T>();        
        }

        public T GetByID(int ID)
        {
            if (ID <= 0)
            {
                return null;
            }

            var context = _contextFactory.GetContext();
            return context.GetTable<T>().Single(entity => (int)typeof(T).GetProperty("ID").GetValue(entity) == ID);
        }

        public T Save(T entity)
        {           
            var context = _contextFactory.GetContext();
            context.GetTable<T>().InsertOnSubmit(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            var context = _contextFactory.GetContext();
            context.GetTable<T>().DeleteOnSubmit(entity);
        }
    }
}
