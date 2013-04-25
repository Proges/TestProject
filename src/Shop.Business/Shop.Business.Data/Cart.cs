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
        private Dictionary<int, int> _cart;

        public Cart()
        {
            _cart = new Dictionary<int, int>();
        }

        public bool AddToCart(int productID, int count)
        {
            var currProduct = _cart.FirstOrDefault(product => product.Key == productID);

            if (currProduct.Key != null)
            {
                var newCount = currProduct.Value + count;

                _cart.Remove(productID);
                _cart.Add(productID, newCount);
                return true;
            }

            _cart.Add(productID, count);
            return true;
        }

        public bool RemoveFromCart(int productID, int count)
        {
            var currProduct = _cart.FirstOrDefault(product => product.Key == productID);

            if (currProduct.Key != null)
            {
                var newCount = currProduct.Value - count;

                if (newCount >= 1)
                {
                    _cart.Remove(productID);
                    _cart.Add(productID, newCount);
                }
                else
                {
                    _cart.Remove(productID);                    
                }
                return true;
            }
            return false;
        }

        public Dictionary<int, int> GetCart()
        {
            return _cart;
        }
    }
}
