using RenoshobeeAPI.Interfaces.OrderInterface;
using RenoshobeeAPI.Model;

namespace RenoshobeeAPI.Implementation
{
    public class OrderServices : IOrderServices
    {
        public decimal CalculateTotalPrice(Order order)
        {
            decimal subtotalprice = 0;
            foreach (var item in order.orderItems)
            {
                item.TotalPrice = item.TotalPrice * item.Quantity;
                subtotalprice += item.TotalPrice;
            }
            order.SubTotalPrice = subtotalprice;
            return(subtotalprice + (decimal)order.ShippingPrice);
        }

        public int CalculateTotalQuantity(Order order)
        {
            int totalquantity = 0;
            foreach (var item in order.orderItems)
            {
                totalquantity += item.Quantity;
            }
            return totalquantity;
        }
    }
}
