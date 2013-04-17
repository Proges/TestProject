using Shop.DataAccess.ContextFactory.Contracts;
using Shop.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.ContextFactory
{
    public class ContextFactory : IContextFactory, IDisposable
    {
        private ShopDevDataContext _context = new ShopDevDataContext();

        public DataContext GetContext()
        {
            if (_context == null)
            {
                _context = new ShopDevDataContext();
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
