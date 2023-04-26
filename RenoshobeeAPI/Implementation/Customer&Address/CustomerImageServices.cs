using RenoshobeeAPI.Model;
using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Models;

namespace RenoshobeeAPI.Implementation.Customer_Address
{
    public class CustomerImageServices : IImageServices<Customer> { 
            private readonly IWebHostEnvironment _webHostEnvironment;
            public CustomerImageServices(IWebHostEnvironment webHostEnvironment)
            {
                _webHostEnvironment = webHostEnvironment;
            }

            public void ImageDelete(Customer customer)
            {
                if (customer.Img_Url != @"\images\No_Image.png")
                {
                    var imgOldPath = _webHostEnvironment.WebRootPath + customer.Img_Url;
                    if (File.Exists(imgOldPath))
                    {
                        File.Delete(imgOldPath);
                    }
                }
            }

            public void ImageEdit(Customer customer, IFormFile? formFile)
            {
                if (formFile != null)
                {
                    ImageDelete(customer);
                    ImageSet(customer, formFile);
                }
            }

            public string ImageGet(Customer customer)
            {
                return customer.Img_Url;
            }

            public void ImageSet(Customer customer, IFormFile? imgFile)
            {
                if (imgFile == null)
                {
                customer.Img_Url = "\\images\\No_Image.png";
                }
                else
                {
                    string imgExtension = Path.GetExtension(imgFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgUrl = "\\images\\" + imgName;
                    customer.Img_Url = imgUrl;

                    string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
                    using (var imgStream = new FileStream(imgPath, FileMode.Create))
                    {
                        imgFile.CopyTo(imgStream);
                    }
                }
            }
    


}
}
