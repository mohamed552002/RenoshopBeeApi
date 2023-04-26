using RenoshobeeAPI.Model;

namespace RenoshobeeAPI.Interfaces.OrderInterface
{
    public interface IOrderServices
    {
        public decimal CalculateTotalPrice(Order order);
        public int CalculateTotalQuantity(Order order);
    }
}
