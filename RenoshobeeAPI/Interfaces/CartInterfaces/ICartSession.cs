using RenoshobeeAPI.Model;
using RenoshopBee.Models;

namespace RenoshobeeAPI.Interfaces.CartInterfaces
{
    public interface ICartSession
    {
        public Cart GetCartFromSession();
        public bool IsNewProduct(Product product);
    }
}
