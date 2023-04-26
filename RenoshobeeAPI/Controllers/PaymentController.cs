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
        public void AddCreditCard(CreditCart creditCard)
        {
            _dbContext.Add(creditCard);
            _dbContext.SaveChanges();
        }
        [HttpGet]
        public CreditCart GetCreditCardById(int id)
        {
            return _dbContext.creditCarts.FirstOrDefault(card => card.Id == id);
        }
        [HttpDelete]
        public void DeleteCreditCard(int id)
        {
            _dbContext.creditCarts.Remove(GetCreditCardById(id));
        }
    }
}
