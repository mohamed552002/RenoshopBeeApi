using RenoshobeeAPI.Model;
using RenoshopBee.Models;

namespace RenoshobeeAPI.Interfaces.CartInterfaces
{
    public interface ICartServices
    {
        public void AddProductToCart(Product product);
        public Cart GetCartItems();
        public void RemoveProductFromCart(int productId);
    }
}
