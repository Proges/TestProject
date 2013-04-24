using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Factory.Tests
{
    public class TestService : ITestService
    {
        string ITestService.Name
        {
            get { return "TestService"; }
        }
    }
}
