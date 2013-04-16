using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class Supplier : ISupplier
    {
        private EntitySet<IProduct> _products;
        
        int ISupplier.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string ISupplier.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        int ISupplier.AddressID
        {
            get { return AddressID; }
            set { AddressID = value; }
        }

        IList<IBanner> ISupplier.Banners
        {
            get { return Banners.ToList<IBanner>(); }
            set
            {
                Banners.Clear();
                Banners.AddRange(value.Cast<Banner>());
            }
        }

        IList<IOrderLine> ISupplier.OrderLines
        {
            get { return OrderLines.ToList<IOrderLine>(); }
            set
            {
                OrderLines.Clear();
                OrderLines.AddRange(value.Cast<OrderLine>());
            }
        }

        IList<IPerson> ISupplier.Persons
        {
            get { return Persons.ToList<IPerson>(); }
            set
            {
                Persons.Clear();
                Persons.AddRange(value.Cast<Person>());
            }
        }

      

        EntityRef<IAddress> ISupplier.Address
        {
            get { return new EntityRef<IAddress>(Address); }
            set { Address = (Address)value.Entity; }
        }

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
                ProductsSuppliers.Add(new ProductsSupplier { Supplier = this, Product = (Product)product });
            }
        }

        private void OnRemoveProduct(IProduct product)
        {
            if (product != null && Products.Contains(product))
            {
                var rProduct = ProductsSuppliers.FirstOrDefault(productSupplier => productSupplier.SupplierID == ID && productSupplier.ProductID == product.ID);
                if (rProduct != null)
                {
                    ProductsSuppliers.Remove(rProduct);
                }
            }
        }
    }
}
