using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Repository.Tests.Data.Contracts
{
    public interface ITestDataContext
    {
        IQueryable<T> GetTestTable<T>() where T:class;
    }
}
