using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================
        // GET ALL
        // =====================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return Ok(categories);
        }

        // =====================
        // GET BY ID
        // =====================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new { message = "Không tìm thấy danh mục" });

            return Ok(category);
        }

        // =====================
        // GET POSTS BY CATEGORY
        // =====================
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPostsByCategory(int id)
        {
            var category = await _context.Categories
                .Include(x => x.Posts)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new { message = "Không tìm thấy danh mục" });

            return Ok(new
            {
                category.Id,
                category.Name,
                category.Description,
                posts = category.Posts.Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.ImageUrl,
                    p.CreatedDate,
                    p.CategoryId
                })
            });
        }

        // =====================
        // CREATE (POST)
        // =====================
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return BadRequest(new { message = "Tên danh mục không được rỗng" });

            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Thêm thành công",
                data = category
            });
        }

        // =====================
        // UPDATE (PUT)
        // =====================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdate model)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound(new { message = "Không tìm thấy danh mục" });

            category.Name = model.Name;
            category.Description = model.Description;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Cập nhật thành công",
                data = category
            });
        }

        // =====================
        // DELETE
        // =====================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound(new { message = "Không tìm thấy danh mục" });

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xoá thành công" });
        }
    }

    // =====================
    // DTO INLINE
    // =====================
    public class CategoryCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryUpdate
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}