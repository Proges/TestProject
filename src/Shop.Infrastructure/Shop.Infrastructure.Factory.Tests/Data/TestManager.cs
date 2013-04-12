using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Factory.Tests
{
    public class TestManager : ITestManager
    {
        public string Name
        {
            get { return "TestManager"; }
        }
    }
}
