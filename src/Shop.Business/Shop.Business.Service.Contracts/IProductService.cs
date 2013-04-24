using Shop.Business.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Service.Contracts
{
    public interface IProductService
    {
        IList<IProductBusiness> SearchProducts(string search);
    }
}
