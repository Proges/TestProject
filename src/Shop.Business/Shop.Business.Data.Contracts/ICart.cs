using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Data.Contracts
{
    public interface ICart
    {
        IUserBusiness User { get; }
        void AddToCart(IProductBusiness product, int count);
        void RemoveFromCart(IProductBusiness product, int count);
        Dictionary<IProductBusiness, int> GetCart();
    }
}
