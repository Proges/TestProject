using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Banner : IBanner
    {
        private EntitySet<IImage> _images;


        partial void OnCreated()
        {
            _images = new EntitySet<IImage>(OnAddImage, OnRemoveImage);
        }

        ISupplier IBanner.Supplier
        {
            get { return Supplier; }
            set { Supplier = (Supplier)value; }
        }

        IList<IBannersImage> IBanner.BannersImages
        {
            get
            {
                return BannersImages.ToList<IBannersImage>();
            }            
        }

        public EntitySet<IImage> Images
        {
            get
            {
                if (_images == null)
                {
                    _images = new EntitySet<IImage>(OnAddImage, OnRemoveImage);
                    _images.SetSource(BannersImages.Select(bi => bi.Image));
                }
                return _images;
            }

            set
            {
                _images.Assign(value);
            }
        }
              

        private void OnAddImage(IImage image)
        {
            if (image != null)
            {
                BannersImages.Add(new BannersImage { Banner = this, Image = (Image)image });
            }
        }    

        private void OnRemoveImage(IImage image)
        {
            if (image != null)
            {
                var rImage = BannersImages.FirstOrDefault(bannerImage => bannerImage.ImageID == image.ID);
                if (rImage != null)
                {
                    BannersImages.Remove(rImage);
                }
            }
        }
    }
}
