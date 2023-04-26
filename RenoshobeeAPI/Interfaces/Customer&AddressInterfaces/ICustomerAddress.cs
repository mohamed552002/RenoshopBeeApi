using RenoshobeeAPI.Model;

namespace RenoshobeeAPI.Interfaces.Customer_AddressInterfaces
{
    public interface ICustomerAddress
    {
        public Task<IEnumerable<Address>> GetAllAddresses();
        public IEnumerable<Customer> AllCustomersWithAddresses(); 
    }
}
