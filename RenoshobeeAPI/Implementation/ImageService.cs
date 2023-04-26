using Microsoft.AspNetCore.Hosting;
using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Models;

namespace RenoshopBee.Implementation

{
    public class ImageService:IImageServices<Product>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void ImageDelete(Product product)
        {
            if (product.Img_url != @"\images\No_Image.png")
            {
                var imgOldPath = _webHostEnvironment.WebRootPath + product.Img_url;
                if (File.Exists(imgOldPath))
                {
                    File.Delete(imgOldPath);
                }
            }
        }

        public void ImageEdit(Product product, IFormFile? formFile)
        {
            if (formFile != null)
            {
                ImageDelete(product);
                ImageSet(product, formFile);
            }
        }

        public string ImageGet(Product product)
        {
            return product.Img_url;
        }

        public void ImageSet(Product product, IFormFile? imgFile)
        {
            if (imgFile == null)
            {
                product.Img_url = "\\images\\No_Image.png";
            }
            else
            {
                string imgExtension = Path.GetExtension(imgFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                product.Img_url = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
                using (var imgStream = new FileStream(imgPath, FileMode.Create))
                {
                    imgFile.CopyTo(imgStream);
                }
            }
        }
    }
}
