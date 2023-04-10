using Microsoft.EntityFrameworkCore;
using RenoshobeeAPI.Data;
using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Models;

namespace RenoshopBee.Implementation
{
    public class ProductContextServices : IProductContext
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductImage _productImage;
        public ProductContextServices(ApplicationDBContext context, IProductImage productImage)
        {
            _context = context;
            _productImage = productImage;
        }

        public void DeleteProduct(Product product)
        {
            if (product != null)
            {
                _productImage.ProductImageDelete(product);
                _context.Products.Remove(product);
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.ID == productId); ;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
