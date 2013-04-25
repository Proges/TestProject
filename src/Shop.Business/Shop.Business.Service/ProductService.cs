using Shop.Business.Data.Contracts;
using Shop.Business.Repository.Contracts;
using Shop.Business.Service.Contracts;
using Shop.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DataAccess.Database;
using Shop.DataAccess.Database.Contracts;

namespace Shop.Business.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;


        public ProductService() : this(null)
        {

        }

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? Factory.GetRepository<IProductRepository>();
        }        
    }
}
