using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Image : IImage
    {
        private EntitySet<IBanner> _banners;
        private EntitySet<IProduct> _products;


        int IImage.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        string IImage.Name
        {
            get { return Name; }
            set { Name = value; }
        }

        string IImage.URL
        {
            get { return URL; }
            set { URL = value; }
        }

        IList<IBannersImage> IImage.BannersImages
        {
            get
            {
                return BannersImages.ToList<IBannersImage>();
            }           
        }

        IList<IBrand> IImage.Brands
        {
            get
            {
                return Brands.ToList<IBrand>();
            }
            set
            {
                Brands.Clear();
                Brands.AddRange(value.Cast<Brand>());
            }
        }

        IList<IProductsImage> IImage.ProductsImages
        {
            get
            {
                return ProductsImages.ToList<IProductsImage>();
            }            
        }


        public EntitySet<IBanner> Banners
        {
            get
            {
                if (_banners != null)
                {
                    _banners = new EntitySet<IBanner>(OnAddBanner, OnRemoveBanner);
                    _banners.SetSource(BannersImages.Select(bi => bi.Banner));
                }
                return _banners;
            }
            set
            {
                _banners.Assign(value);
            }
        }

        public EntitySet<IProduct> Products
        {
            get
            {
                if (_products != null)
                {
                    _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
                    _products.SetSource(ProductsImages.Select(pi => pi.Product));
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
            _banners = new EntitySet<IBanner>(OnAddBanner, OnRemoveBanner);
            _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
        }

        private void OnAddBanner(IBanner banner)
        {
            if (banner != null && !Banners.Contains(banner))
            {
                BannersImages.Add(new BannersImage { Image = this, Banner = (Banner)banner });
            }
        }

        private void OnRemoveBanner(IBanner banner)
        {
            if (banner != null && Banners.Contains(banner))
            {
                var rBanner = BannersImages.FirstOrDefault(bannersImages => bannersImages.BannerID == banner.ID && bannersImages.ImageID == ID);
                BannersImages.Remove(rBanner);
            }
        }        

        private void OnAddProduct(IProduct product)
        {
            if (product != null && !Products.Contains(product))
            {
                ProductsImages.Add(new ProductsImage { Image = this, Product = (Product)product });
            }
        }

        private void OnRemoveProduct(IProduct product)
        {
            if (product != null && Products.Contains(product))
            {
                var rProduct = ProductsImages.FirstOrDefault(productsImages => productsImages.ProductID == product.ID && productsImages.ImageID == ID);
                ProductsImages.Remove(rProduct);
            }
        }
    }
}
