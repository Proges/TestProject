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
    public class ContextFactory : IContextFactory
    {
        private ShopDevDataContext _context = new ShopDevDataContext();

        public DataContext GetContext()
        {
            return _context;
        }

        public void Commit()
        {
            _context.SubmitChanges();
        }

        public void Rollback()
        {
            var changes = _context.GetChangeSet();

            changes.Deletes.Clear();
            changes.Inserts.Clear();
            changes.Updates.Clear();
        }
    }
}
