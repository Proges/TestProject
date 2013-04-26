using Shop.DataAccess.ContextFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shop.DataAccess.ContextFactory
{
    public class DbSession : IDbSession
    {
        #region Variables

        static DbSession _instance = new DbSession();

        private IContextFactory _contextFactory = new ContextFactory();

        #endregion

        public IContextFactory ContextFactory
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items["DbContextFactory"] == null)
                    {
                        HttpContext.Current.Items["DbContextFactory"] = new ContextFactory();
                    }
                    var factory = HttpContext.Current.Items["DbContextFactory"] as IContextFactory;
                    return factory;

                }
                return _contextFactory;
            }
        }

        public static DbSession Instance
        {
            get { return _instance ?? (_instance = new DbSession()); }
        }
        
    }
}
