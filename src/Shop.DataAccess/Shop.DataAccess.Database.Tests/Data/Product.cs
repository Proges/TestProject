using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class Product : IProduct
    {
        private EntitySet<IImage> _images;
        private EntitySet<ICategory> _categories;
        private EntitySet<ISupplier> _suppliers;


        int IProduct.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string IProduct.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        int IProduct.Price
        {
            get { return Price; }
            set
            {
                if (value >= 0)
                {
                    Price = value;
                }
                else
                {
                    Price = 0;
                }
            }
        }

        int IProduct.BrandID
        {
            get { return BrandID; }
            set { BrandID = value; }
        }

        IList<IOrderLine> IProduct.OrderLines
        {
            get
            {
                return OrderLines.ToList<IOrderLine>();
            }
            set
            {
                OrderLines.Clear();
                OrderLines.AddRange(value.Cast<OrderLine>());
            }
        }             

        IList<IStorageRecord> IProduct.StorageRecords
        {
            get
            {
                return StorageRecords.ToList<IStorageRecord>();
            }
            set
            {
                StorageRecords.Clear();
                StorageRecords.AddRange(value.Cast<StorageRecord>());
            }
        }

        EntityRef<IBrand> IProduct.Brand
        {
            get { return new EntityRef<IBrand>(Brand); }
            set { Brand = (Brand)value.Entity; }
        }
        
        IList<IProductsSupplier> IProduct.ProductsSuppliers
        {
            get
            {
                return ProductsSuppliers.ToList<IProductsSupplier>();
            }            
        }

        IList<IProductsCategory> IProduct.ProductsCategories
        {
            get
            {
                return ProductsCategories.ToList<IProductsCategory>();
            }            
        }

        IList<IProductsImage> IProduct.ProductsImages
        {
            get
            {
                return ProductsImages.ToList<IProductsImage>();
            }            
        }


        public EntitySet<IImage> Images
        {
            get
            {
                if (_images == null)
                {
                    _images = new EntitySet<IImage>(OnAddImage, OnRemoveImage);
                    _images.SetSource(ProductsImages.Select(pi => pi.Image));
                }
                return _images;
            }
            set
            {
                _images.Assign(value);
            }
        }
        public EntitySet<ICategory> Categories 
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new EntitySet<ICategory>(OnAddCategories, OnRemoveCategories);
                    _categories.SetSource(ProductsCategories.Select(pi => pi.Category));
                }
                return _categories;
            }
            set
            {
                _categories.Assign(value);
            }
        }
        public EntitySet<ISupplier> Suppliers 
        {
            get
            {
                if (_suppliers == null)
                {
                    _suppliers = new EntitySet<ISupplier>(OnAddSupplier, OnRemoveSupplier);
                    _suppliers.SetSource(ProductsSuppliers.Select(pi => pi.Supplier));
                }
                return _suppliers;
            }
            set
            {
                _suppliers.Assign(value);
            } 
        }        

        partial void OnCreated()
        {
            _images = new EntitySet<IImage>(OnAddImage, OnRemoveImage);
            _suppliers = new EntitySet<ISupplier>(OnAddSupplier, OnRemoveSupplier);
            _categories = new EntitySet<ICategory>(OnAddCategories, OnRemoveCategories);
        }

        private void OnAddImage(IImage image)
        {
            if (image != null && !Images.Contains(image))
            {
                ProductsImages.Add(new ProductsImage { Product = this, Image = (Image)image });
            }
        }

        private void OnRemoveImage(IImage image)
        {
            if (image != null && Images.Contains(image))
            {
                var rImage = ProductsImages.FirstOrDefault(productImage => productImage.ImageID == image.ID && productImage.ProductID == ID);

                if (rImage != null)
                {
                    ProductsImages.Remove(rImage);
                }
            }
        } 

        private void OnAddCategories(ICategory category)
        {
            if (category != null && !Categories.Contains(category))
            {
                ProductsCategories.Add(new ProductsCategory { Product = this, Category = (Category)category });
            }
        }

        private void OnRemoveCategories(ICategory category)
        {
            if (category != null && Categories.Contains(category))
            {
                var rCategory = ProductsCategories.FirstOrDefault(productCategory => productCategory.CategoryID == category.ID && productCategory.ProductID == ID);

                if (rCategory != null)
                {
                    ProductsCategories.Remove(rCategory);
                }
            }
        }

        private void OnAddSupplier(ISupplier supplier)
        {
            if (supplier != null && !Suppliers.Contains(supplier))
            {
                ProductsSuppliers.Add(new ProductsSupplier { Product = this, Supplier = (Supplier)supplier });
            }
        }

        private void OnRemoveSupplier(ISupplier supplier)
        {
            if (supplier != null && Suppliers.Contains(supplier))
            {
                var rSupplier = ProductsSuppliers.FirstOrDefault(productSupplier => productSupplier.SupplierID == supplier.ID && productSupplier.ProductID == ID);

                if (rSupplier != null)
                {
                    ProductsSuppliers.Remove(rSupplier);
                }
            }
        }       
    }
}
