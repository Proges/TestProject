using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Data.Contracts
{
    public interface ICart
    {
        bool AddToCart(int productID, int count);
        bool RemoveFromCart(int productID, int count);
        Dictionary<int, int> GetCart();
    }
}
