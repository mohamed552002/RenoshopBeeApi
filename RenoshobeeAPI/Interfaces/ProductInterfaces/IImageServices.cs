using RenoshopBee.Models;

namespace RenoshopBee.Interfaces.ProductInterfaces
{
    public interface IImageServices<in T> where T : class
    {
        public void ImageSet(T model, IFormFile? imgFile);
        public string ImageGet(T model);
        public void  ImageDelete(T model);
        public void ImageEdit(T model,IFormFile? formFile);

    }
}
