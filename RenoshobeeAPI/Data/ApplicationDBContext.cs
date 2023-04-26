using Microsoft.EntityFrameworkCore;
using RenoshobeeAPI.Model;
using RenoshopBee.Models;

namespace RenoshobeeAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }   
        public DbSet<Customer> customers { get; set; }   
        public DbSet<Address> Addresses { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CreditCart> creditCarts { get; set; }
    }
}
