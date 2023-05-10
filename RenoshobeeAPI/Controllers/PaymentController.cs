using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenoshobeeAPI.Data;
using RenoshobeeAPI.Model;

namespace RenoshobeeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public PaymentController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult AddCreditCard(CreditCart creditCard)         
        {
            if (ModelState.IsValid)
            {
                creditCard.Order = _dbContext.Orders.Find(creditCard.OrderId);
                creditCard.Balance = creditCard.Balance - creditCard.Order.TotalPrice;
                _dbContext.Add(creditCard);
                _dbContext.SaveChanges();
                return Ok(creditCard);
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult GetCreditCardById(int id)
        {
            if (_dbContext.creditCarts.Any(c => c.Id == id))
            {
                return Ok(_dbContext.creditCarts.FirstOrDefault(card => card.Id == id));
            }
            return NotFound("No Credit Card With this id has been found");

        }
        [HttpDelete]
        public ActionResult DeleteCreditCard(int id)
        {
            if (_dbContext.creditCarts.Any(c => c.Id == id))
            {
                _dbContext.creditCarts.Remove(_dbContext.creditCarts.FirstOrDefault(card => card.Id == id));
                _dbContext.SaveChanges();
                return Ok();
            }
            return NotFound("No Credit Card With this id has been found");
        }
    }
}
