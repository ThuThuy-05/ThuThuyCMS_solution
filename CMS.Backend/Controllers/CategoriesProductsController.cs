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

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        public async Task<IActionResult> Create(CategoryProductCreate model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return BadRequest(new { message = "Tên danh mục không được rỗng" });
            }

            var category = new CategoryProduct
            {
                Name = model.Name,
                Description = model.Description
            };

            _context.CategoryProducts.Add(category);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Thêm danh mục sản phẩm thành công",
                data = category
            });
        }

        // =========================
        // UPDATE (PUT)
        // =========================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryProductUpdate model)
        {
            var category = await _context.CategoryProducts.FindAsync(id);

            if (category == null)
            {
                return NotFound(new { message = "Không tìm thấy danh mục" });
            }

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return BadRequest(new { message = "Tên danh mục không được rỗng" });
            }

            category.Name = model.Name;
            category.Description = model.Description;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Cập nhật thành công",
                data = category
            });
        }

        // =========================
        // DELETE
        // =========================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.CategoryProducts.FindAsync(id);

            if (category == null)
            {
                return NotFound(new { message = "Không tìm thấy danh mục" });
            }

            _context.CategoryProducts.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Xoá thành công"
            });
        }
    }

    // =========================
    // DTO (INLINE)
    // =========================
    public class CategoryProductCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryProductUpdate
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}