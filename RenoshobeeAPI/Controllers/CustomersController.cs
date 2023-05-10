using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RenoshobeeAPI.Data;
using RenoshobeeAPI.Interfaces.Customer_AddressInterfaces;
using RenoshobeeAPI.Model;
using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Models;
using AutoMapper;

namespace RenoshobeeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICustomerAddress _address;
        private readonly IImageServices<Customer> _ImageServices;
        private readonly IDateServices<Customer> _date;
        public CustomersController(ApplicationDBContext context, ICustomerAddress address,
            IImageServices<Customer> ImageServices, IDateServices<Customer> date)
        {
            _context = context;
            _address = address;
            _ImageServices = ImageServices;
            _date = date;
        }
        [HttpGet]
        public async Task<ActionResult> ListAllCustomers()
        {
            await _context.Orders.ToListAsync();
            await _address.GetAllAddresses();
            return Ok(await _context.customers.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromForm] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (await _context.customers.FirstOrDefaultAsync(c => c.Email == customer.Email) != null)
                {
                    return BadRequest("Email must be unique");
                }
                    _ImageServices.ImageSet(customer, customer.Imgfile);
                    _date.SetDateToNow(customer);
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return Ok(customer);
                
            }
            return UnprocessableEntity();
        }
        [HttpPut]
        public async Task<ActionResult> EditCustomer(int id,[FromForm] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Orders = await _context.Orders.Where(order => order.CustomerId == id).ToListAsync();
                _ImageServices.ImageEdit(customer, customer.Imgfile);
                _date.SetUpdatedAtNow(customer);
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return Ok(customer);
            }
            return UnprocessableEntity();
        }
        [HttpDelete]
        public async Task DeleteCustomerById(int id)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(x => x.Id == id);
            _ImageServices.ImageDelete(customer);
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }

    }
}
