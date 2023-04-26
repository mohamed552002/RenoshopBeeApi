using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenoshobeeAPI.Data;
using RenoshobeeAPI.Implementation;
using RenoshobeeAPI.Interfaces.CartInterfaces;
using RenoshobeeAPI.Model;
using RenoshopBee.Models;

namespace RenoshobeeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICartServices _cartServices;
        public CartController(ApplicationDBContext context, ICartServices cartServices)
        {
            _cartServices = cartServices;
            _context = context;
        }
        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            var product =  _context.Products.Find(id);
             _cartServices.AddProductToCart(product);
            return Ok();
        }
        [HttpGet]
        public ActionResult<Cart> GetCart()
        {
            return _cartServices.GetCartItems();
        }
        [HttpDelete]
        public ActionResult RemoveFromCart(int id) 
        {
            _cartServices.RemoveProductFromCart(id);
            return Ok();
        }
    }
}
