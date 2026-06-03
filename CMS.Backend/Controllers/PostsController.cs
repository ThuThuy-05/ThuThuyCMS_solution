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

        // =========================
        // GET ALL
        // =========================
        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _context.Posts
                .OrderByDescending(p => p.Id)
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

        // =========================
        // GET BY CATEGORY
        // =========================
        [HttpGet("category/{categoryId}")]
        public IActionResult GetByCategory(int categoryId)
        {
            var posts = _context.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.ImageUrl,
                    p.CreatedDate
                })
                .ToList();

            return Ok(posts);
        }

        // =========================
        // GET DETAIL
        // =========================
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
                    p.CategoryId
                })
                .FirstOrDefault();

            if (post == null)
            {
                return NotFound(new { message = "Không tìm thấy bài viết" });
            }

            return Ok(post);
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        public async Task<IActionResult> Create(PostCreate model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                return BadRequest(new { message = "Tiêu đề không được rỗng" });
            }

            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                ImageUrl = model.ImageUrl,
                CreatedDate = DateTime.Now,
                CategoryId = model.CategoryId
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Thêm bài viết thành công",
                data = post
            });
        }

        // =========================
        // UPDATE (PUT)
        // =========================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostUpdate model)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound(new { message = "Không tìm thấy bài viết" });
            }

            post.Title = model.Title;
            post.Content = model.Content;
            post.ImageUrl = model.ImageUrl;
            post.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Cập nhật thành công",
                data = post
            });
        }

        // =========================
        // DELETE
        // =========================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound(new { message = "Không tìm thấy bài viết" });
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Xoá thành công"
            });
        }
    }

    public class PostCreate
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }

    public class PostUpdate
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}