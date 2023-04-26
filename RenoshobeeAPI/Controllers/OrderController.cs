using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenoshobeeAPI.Data;
using RenoshobeeAPI.Interfaces.OrderInterface;
using RenoshobeeAPI.Model;

namespace RenoshobeeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IOrderServices _orderServices;
        public OrderController(ApplicationDBContext dbContext, IOrderServices orderServices)
        {
            _dbContext = dbContext;
            _orderServices = orderServices;
        }
        [HttpPost]
        public void MakeOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.TotalQuantity = _orderServices.CalculateTotalQuantity(order);
            order.TotalPrice = _orderServices.CalculateTotalPrice(order);   
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            _dbContext.OrderItems.ToList();
            return _dbContext.Orders.ToList();
        }

        
            
    }
}
