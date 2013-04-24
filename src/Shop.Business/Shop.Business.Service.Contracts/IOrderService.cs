using Shop.Business.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Service.Contracts
{
    public interface IOrderService
    {
        bool AddToCart(IOrderBusiness order, int productID, int count);
        void RemoveFromCart(IOrderBusiness order, int productID, int count);
        IList<IOrderLineBusiness> GetCart(IOrderBusiness order);
        void MakeOrder(IOrderBusiness order);
    }
}
