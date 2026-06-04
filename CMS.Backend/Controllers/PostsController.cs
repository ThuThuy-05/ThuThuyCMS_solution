using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==================================================
        // 1. GET /api/Posts
        // 👉 FE: LatestBlog (Tầng 5)
        // 👉 Lấy bài viết mới nhất
        // ==================================================
        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _context.Posts
                .OrderByDescending(p => p.CreatedDate)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.ImageUrl,
                    p.CreatedDate,
                    CategoryName = p.Category.Name
                })
                .ToList();

            return Ok(posts);
        }

        // ==================================================
        // 2. GET /api/Posts/{id}
        // 👉 FE: xem chi tiết bài viết
        // ==================================================
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var post = _context.Posts
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.ImageUrl,
                    p.CreatedDate,
                    p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefault();

            if (post == null)
            {
                return NotFound(new { message = "Không tìm thấy bài viết" });
            }

            return Ok(post);
        }

        // ==================================================
        // 3. GET /api/Posts/category/{categoryId}
        // 👉 FE: filter theo danh mục (optional UI)
        // ==================================================
        [HttpGet("category/{categoryId}")]
        public IActionResult GetByCategory(int categoryId)
        {
            var posts = _context.Posts
                .Where(p => p.CategoryId == categoryId)
                .OrderByDescending(p => p.CreatedDate)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.ImageUrl,
                    p.CreatedDate
                })
                .ToList();

            return Ok(posts);
        }
    }
}