using Shop.DataAccess.ContextFactory.Contracts;
using Shop.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.ContextFactory
{
    public class ContextFactory : IContextFactory, IDisposable
    {
        private DataContext _context;
        private MappingSource _mapping;

        public DataContext GetContext()
        {
            if (_context == null)
            {
                _mapping = new AttributeMappingSource();
                _context = new DataContext(ConfigurationManager.ConnectionStrings["ShopDevConnectionString"].ConnectionString, _mapping);
            }
            return _context;
        }

        public void Commit()
        {
            _context.SubmitChanges();
        }

        public void Rollback()
        {
            _context = null;
        }

        public ChangeSet GetChanges
        {
            get { return _context.GetChangeSet(); }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
