using Shop.Business.Data.Contracts;
using Shop.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Data
{
    public class Cart : ICart
    {
        private Dictionary<IProductBusiness, int> _cart;
        private IUserBusiness _user;


        public IUserBusiness User { get { return _user; } }

        public Cart(IUserBusiness user)
        {
            _cart = new Dictionary<IProductBusiness, int>();
            _user = user;
        }
        
        public void AddToCart(IProductBusiness product, int count)
        {
            if (_cart.Keys.FirstOrDefault(p => p.ID == product.ID) == null)
            {
                _cart.Add(product, count);
            }
        }

        public void RemoveFromCart(IProductBusiness product, int count)
        {
            var currProduct = _cart.FirstOrDefault(prod => prod.Key.ID == product.ID);
            
                var newCount = currProduct.Value - count;

                if (newCount >= 1)
                {
                    _cart.Remove(product);
                    _cart.Add(product, newCount);
                }
                else
                {
                    _cart.Remove(product);                    
                }
        }

        public Dictionary<IProductBusiness, int> GetCart()
        {
            return _cart;
        }
    }
}
