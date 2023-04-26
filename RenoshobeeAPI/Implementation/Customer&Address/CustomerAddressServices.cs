using Microsoft.EntityFrameworkCore;
using RenoshobeeAPI.Data;
using RenoshobeeAPI.Interfaces.Customer_AddressInterfaces;
using RenoshobeeAPI.Model;

namespace RenoshobeeAPI.Implementation.Customer_Address
{
    public class CustomerAddressServices : ICustomerAddress
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerAddressServices(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> AllCustomersWithAddresses()
        {
            var customersWithAddresses = _dbContext.customers.Include(c => c.address).ToList();
            return customersWithAddresses;
        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await _dbContext.Addresses.ToListAsync();
        }
    }
}
