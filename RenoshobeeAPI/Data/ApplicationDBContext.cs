using Microsoft.EntityFrameworkCore;
using RenoshopBee.Models;

namespace RenoshobeeAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
