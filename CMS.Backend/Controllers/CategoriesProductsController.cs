using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET ALL
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.CategoryProducts
                .OrderByDescending(x => x.Id)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Description
                })
                .ToListAsync();

            return Ok(categories);
        }

        // =========================
        // GET BY ID
        // =========================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var category = await _context.CategoryProducts
                .Where(x => x.Id == id)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Description
                })
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound(new { message = "Không tìm thấy danh mục" });
            }

            return Ok(category);
        }

    }
}