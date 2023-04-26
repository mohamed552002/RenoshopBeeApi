using RenoshobeeAPI.Model;
using RenoshopBee.Interfaces.ProductInterfaces;

namespace RenoshobeeAPI.Implementation.Customer_Address
{
    public class CustomertDateServices:IDateServices<Customer>
    {
        public void SetDateToNow(Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            customer.LastUpdatedAt = DateTime.Now;
        }


        public void SetUpdatedAtNow(Customer customer)
        {
            customer.LastUpdatedAt = DateTime.Now;
        }
    }
}
