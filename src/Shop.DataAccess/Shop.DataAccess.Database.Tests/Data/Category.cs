using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class Category : ICategory
    {
        private EntitySet<IProduct> _products;

        int ICategory.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int? ICategory.ParentCategoryID
        {
            get { return ParentCategoryID; }
            set { ParentCategoryID = value; }
        }

        string ICategory.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        string ICategory.Description
        {
            get { return Description; }
            set { Description = value; }
        }

        IList<ICategory> ICategory.Categories
        {
            get
            {
                return Categories.ToList<ICategory>();
            }
            set
            {
                Categories.Clear();
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

        EntityRef<ICategory> ICategory.Category1
        {
            get { return new EntityRef<ICategory>(Category1); }
            set { Category1 = (Category)value.Entity; }
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


        partial void OnCreated()
        {
            _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
        }

        private void OnAddProduct(IProduct product)
        {
            if (product != null && !Products.Contains(product))
            {
                ProductsCategories.Add(new ProductsCategory { Category = this, Product = (Product)product });
            }
        }

        private void OnRemoveProduct(IProduct product)
        {
            if (product != null && Products.Contains(product))
            {
                var rProduct = ProductsCategories.FirstOrDefault(productCategory => productCategory.ProductID == product.ID && productCategory.CategoryID == ID);

                if (rProduct != null)
                {
                    ProductsCategories.Remove(rProduct);
                }
            }
        }
    }
}
