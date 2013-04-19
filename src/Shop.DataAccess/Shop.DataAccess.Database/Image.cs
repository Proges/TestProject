using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Image : IImage, IEntity<IImage>
    {
        private EntitySet<IBanner> _banners;
        private EntitySet<IProduct> _products;


        partial void OnCreated()
        {
            _banners = new EntitySet<IBanner>(OnAddBanner, OnRemoveBanner);
            _products = new EntitySet<IProduct>(OnAddProduct, OnRemoveProduct);
        }


        public int Identifier { get; set; }

        IList<IBrand> IImage.Brands
        {
            get
            {
                return Brands.ToList<IBrand>();
            }
            set
            {
                Brands = new EntitySet<Brand>();
                Brands.AddRange(value.Cast<Brand>());
            }
        }

        #region BannersImages
        IList<IBannersImage> IImage.BannersImages
        {
            get
            {
                return BannersImages.ToList<IBannersImage>();
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
        }

        private void OnAddBanner(IBanner banner)
        {
            if (banner != null && !Banners.Select(b => b.ID).Contains(banner.ID))
            {
                BannersImages.Add(new BannersImage { Image = this, Banner = (Banner)banner });
            }
        }

        private void OnRemoveBanner(IBanner banner)
        {
            if (banner != null)
            {
                var rBanner = BannersImages.FirstOrDefault(bannersImages => bannersImages.BannerID == banner.ID);
                BannersImages.Remove(rBanner);
            }
        }
        #endregion

        #region ProductsImages
        IList<IProductsImage> IImage.ProductsImages
        {
            get
            {
                return ProductsImages.ToList<IProductsImage>();
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
        }

        private void OnAddProduct(IProduct product)
        {
            if (product != null && !Products.Select(p => p.ID).Contains(product.ID))
            {
                ProductsImages.Add(new ProductsImage { Image = this, Product = (Product)product });
            }
        }

        private void OnRemoveProduct(IProduct product)
        {
            if (product != null && Products.Contains(product))
            {
                var rProduct = ProductsImages.FirstOrDefault(productsImages => productsImages.ProductID == product.ID);
                ProductsImages.Remove(rProduct);
            }
        }
        #endregion       
    }
}
