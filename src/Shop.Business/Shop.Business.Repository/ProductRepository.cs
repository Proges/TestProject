using Shop.Business.Data.Contracts;
using Shop.Business.Repository.Contracts;
using Shop.DataAccess.Database;
using Shop.DataAccess.Database.Contracts;
using Shop.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Repository
{
    public class ProductRepository : Repository<IProductBusiness>, IProductRepository
    {        
        public IQueryable<IProductBusiness> SearchProducts(string search)
        {
            var productsList = GetAll().Where(products => search.Contains(products.Brand.Name) || search.Contains(products.Name) ||
                                         search.Intersect(products.Categories.Select(c => c.Name).ToString()).ToList() != null)
                                     .Cast<IProductBusiness>();
            return productsList;
        }
    }
}
