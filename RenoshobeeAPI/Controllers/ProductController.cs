using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RenoshobeeAPI.Data;
using RenoshopBee.Interfaces.ProductInterfaces;
using RenoshopBee.Models;


namespace RenoshobeeAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductContext _productContext;
        private readonly IProductImage _productImage;
        private readonly IProductDate _productDate;
        public ProductController(ApplicationDBContext context, IProductImage productImage, IProductDate productDate, IProductContext productContext)
        {
            _context = context;
            _productImage = productImage;
            _productDate = productDate;
            _productContext = productContext;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _context.Products.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _productImage.ProductImageSet(product, product.ImgFile);
                _productDate.SetProductDatesToNow(product);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            return UnprocessableEntity(product);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _productContext.GetProductByIdAsync(id);
            _productContext.DeleteProduct(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id,[FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _productImage.ProductImageEdit(product, product.ImgFile);
                _productDate.SetProductUpdatedAtNow(product);
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(product);
        }
    }
}
