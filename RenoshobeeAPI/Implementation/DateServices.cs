using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Models;

namespace RenoshopBee.Implementation
{
    public class DateServices:IDateServices<Product>
    {
        public void SetDateToNow(Product product)
        {
            product.Created_at = DateTime.Now;
            product.Last_updated_at = DateTime.Now;
        }


        public void SetUpdatedAtNow(Product product)
        {
            product.Last_updated_at = DateTime.Now;
        }
    }
}
