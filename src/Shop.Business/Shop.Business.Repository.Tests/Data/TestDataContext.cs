using Shop.Business.Repository.Tests.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq.Mapping;

namespace Shop.Business.Repository.Tests.Data
{
    public class TestDataContext : DataContext, ITestDataContext
    {
        public TestDataContext(string connection, MappingSource source)
            :base(connection, source)
        {
        }

        public virtual IQueryable<T> GetTestTable<T>() where T: class
        {
            return this.GetTable<T>();
        }      
    }
}
