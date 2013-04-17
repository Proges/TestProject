using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Category : ICategory
    {
        private EntitySet<IProduct> _products;


        partial void OnCreated()
        {
            _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
        }

        IList<ICategory> ICategory.Categories
        {
            get
            {
                return Categories.ToList<ICategory>();
            }
            set
            {
                Categories = new EntitySet<Category>();
                Categories.AddRange(value.Cast<Category>());
            }
        }

        IList<IProductsCategory> ICategory.ProductsCategories
        {
            get
            {
                return ProductsCategories.ToList<IProductsCategory>();
            }           
        }

        EntityRef<ICategory> ICategory.ParentCategory
        {
            get { return new EntityRef<ICategory>(ParentCategory); }
            set { ParentCategory = (Category)value.Entity; }
        }


        public EntitySet<IProduct> Products
        {
            get
            {
                if (_products != null)
                {
                    _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
                    _products.SetSource(ProductsCategories.Select(pc => pc.Product));
                }
                return _products;
            }
            set
            {
                _products.Assign(value);
            }
        }     

        private void OnAddProduct(IProduct product)
        {
            if (product != null)
            {
                ProductsCategories.Add(new ProductsCategory { Category = this, Product = (Product)product });
            }
        }

        private void OnRemoveProduct(IProduct product)
        {
            if (product != null)
            {
                var rProduct = ProductsCategories.FirstOrDefault(productCategory => productCategory.ProductID == product.ID);

                if (rProduct != null)
                {
                    ProductsCategories.Remove(rProduct);
                }
            }
        }
    }
}
