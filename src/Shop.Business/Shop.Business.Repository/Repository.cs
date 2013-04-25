using Shop.Business.Data;
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
        where T: IEntity<T>
    {
        protected IContextFactory _contextFactory;

        
        public Repository()
        {
            _contextFactory = Factory.GetComponent<IContextFactory>();
        }
        
        public IQueryable<T> GetAll()
        {
            var context = _contextFactory.GetContext();
            var type = Factory.GetComponent<T>().GetType().BaseType;
            return (IQueryable<T>)(context.GetTable(type).Cast<T>());           
        }

        public T GetByID(int ID)
        {
            var context = _contextFactory.GetContext();
            var type = Factory.GetComponent<T>().GetType().BaseType;
            return ((IQueryable<T>)(context.GetTable(type).Cast<T>())).Single(entity => entity.Identifier == ID);
        }

        public T Save(T entity)
        {           
            var context = _contextFactory.GetContext();
            var type = Factory.GetComponent<T>().GetType().BaseType;
            var table = (IQueryable<T>)(context.GetTable(type).Cast<T>());
            var currEntity = table.FirstOrDefault(ent => ent.Identifier == entity.Identifier);

            if (currEntity == null)
            {
                context.GetTable(type).InsertOnSubmit(entity);
            }
            else
            {
                currEntity = entity;
            }

            return entity;
        }

        public void Delete(T entity)
        {
            var context = _contextFactory.GetContext();
            var type = Factory.GetComponent<T>().GetType().BaseType;
            var table = (IQueryable<T>)(context.GetTable(type).Cast<T>());

            if (table.FirstOrDefault(ent => ent.Identifier == entity.Identifier) != null)
            {
                context.GetTable(type).DeleteOnSubmit(entity);
            }
        }
    }
}
