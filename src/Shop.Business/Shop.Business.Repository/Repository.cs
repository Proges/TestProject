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
        where T: class, IEntity<int>
    {
        private DataContext _context;

        public Repository()
        {
            _context = DbSession.Instance.ContextFactory.GetContext();
        }
        
        public IQueryable<T> GetAll()
        {
            return (IQueryable<T>)(_context.GetTable(ResolveType()).Cast<T>());           
        }

        public T GetByID(int ID)
        {
            return _context.GetTable(ResolveType()).Cast<T>().FirstOrDefault(entity => entity.Identifier == ID);
        }

        public T Save(T entity)
        {
            var table = _context.GetTable(ResolveType());
           
            if (table.GetOriginalEntityState(entity) == null)
            {
                table.InsertOnSubmit(entity);
            }

            return entity;
        }

        public void Delete(T entity)
        {
            if (GetByID(entity.Identifier) != null)
            {
                _context.GetTable(ResolveType()).DeleteOnSubmit(entity);
            }
        }

        private Type ResolveType()
        {
            var type = Factory.GetComponent<T>().GetType().BaseType;
            return type;
        }
    }
}
