using Newtonsoft.Json;
using RenoshobeeAPI.Interfaces.CartInterfaces;
using RenoshobeeAPI.Model;
using RenoshopBee.Models;

namespace RenoshobeeAPI.Implementation
{
    public class CartServices :ICartServices
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CartServices(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        private Cart GetCartFromSession()
        {
            var cartJson = _contextAccessor.HttpContext.Session.GetString("_cart");
            return string.IsNullOrEmpty(cartJson) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson);
        }
        private void SaveCartToSession(Cart cart)
        {
            _contextAccessor.HttpContext.Session.SetString("_cart", JsonConvert.SerializeObject(cart));
        }
        private bool IsNewProduct(Product product)
        {
            var cart = GetCartFromSession();
            return cart.products==null?true:!(cart.products.Any(p => p.ID == product.ID)) ;
        }

        public void AddProductToCart(Product product)
        {
            var cart = GetCartFromSession();
            if (IsNewProduct(product))
            {
                cart.products = new List<Product>();
                cart.products.Add(product);
            }
            else
            {
                throw new InvalidOperationException("Product already in cart");
            }
            SaveCartToSession(cart);
        }

        public Cart GetCartItems()
        {
            return GetCartFromSession();
        }

        public void RemoveProductFromCart(int productId)
        {
            var cart = GetCartItems();
            Product product = cart.products.Where(product => product.ID == productId).FirstOrDefault();
            cart.products.Remove(product);
            SaveCartToSession(cart) ;
        }
    }
}
