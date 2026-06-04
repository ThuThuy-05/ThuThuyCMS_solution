using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==================================================
        // GET /api/Products
        // 👉 ProductGrid (Tầng 4)
        // ==================================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products
                .OrderByDescending(p => p.Id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.ImageUrl
                })
                .ToListAsync();

            return Ok(products);
        }

        // ==================================================
        // GET /api/Products/category/{categoryProductId}
        // 👉 Filter Shop.jsx
        // ==================================================
        [HttpGet("category/{categoryProductId}")]
        public async Task<IActionResult> GetByCategory(int categoryProductId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryProductId == categoryProductId)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.ImageUrl
                })
                .ToListAsync();

            return Ok(products);
        }

        // ==================================================
        // GET /api/Products/{id}
        // 👉 ProductDetail.jsx
        // ==================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.StockQuantity,
                    p.ImageUrl,
                    p.CategoryProductId
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm" });
            }

            return Ok(product);
        }


    }
}