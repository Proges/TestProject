using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Supplier : ISupplier, IEntity<ISupplier>
    {
        public int Identifier { get; set; }

        private EntitySet<IProduct> _products;

        partial void OnCreated()
        {
            _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
        }

        IList<IBanner> ISupplier.Banners
        {
            get { return Banners.ToList<IBanner>(); }
            set
            {
                Banners = new EntitySet<Banner>();
                Banners.AddRange(value.Cast<Banner>());
            }
        }

        IList<IOrderLine> ISupplier.OrderLines
        {
            get { return OrderLines.ToList<IOrderLine>(); }
            set
            {
                OrderLines = new EntitySet<OrderLine>();
                OrderLines.AddRange(value.Cast<OrderLine>());
            }
        }

        IList<IPerson> ISupplier.Persons
        {
            get { return Persons.ToList<IPerson>(); }
            set
            {
                Persons = new EntitySet<Person>();
                Persons.AddRange(value.Cast<Person>());
            }
        }      

        IAddress ISupplier.Address
        {
            get { return Address; }
            set { Address = (Address)value; }
        }

        #region ProductsSuppliers
        IList<IProductsSupplier> ISupplier.ProductsSuppliers
        {
            get { return ProductsSuppliers.ToList<IProductsSupplier>(); }
        }

        public EntitySet<IProduct> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
                    _products.SetSource(ProductsSuppliers.Select(ps =>ps.Product));
                }
                return _products;
            }
        }       

        private void OnAddProduct(IProduct product)
        {
            if (product != null && !Products.Select(p => p.ID).Contains(product.ID))
            {
                ProductsSuppliers.Add(new ProductsSupplier { Supplier = this, Product = (Product)product });
            }
        }

        private void OnRemoveProduct(IProduct product)
        {
            if (product != null)
            {
                var rProduct = ProductsSuppliers.FirstOrDefault(productSupplier => productSupplier.ProductID == product.ID);
                if (rProduct != null)
                {
                    ProductsSuppliers.Remove(rProduct);
                }
            }
        }
        #endregion
    }
}
