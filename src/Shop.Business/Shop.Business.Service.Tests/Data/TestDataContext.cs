using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq.Mapping;

namespace Shop.Business.Service.Tests.Data
{
    public class TestDataContext : DataContext
    {
        public TestDataContext(string connection, MappingSource source)
            :base(connection, source)
        {
        }

        public virtual ITable GetTestTable(Type type)
        {
            return (ITable)(new List<TestUser>());
        }      
    }
}
