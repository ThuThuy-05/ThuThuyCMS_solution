using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================
        // GET ALL
        // =====================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return Ok(users);
        }

        // =====================
        // GET BY ID
        // =====================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound(new { message = "Không tìm thấy user" });

            return Ok(user);
        }

        // =====================
        // CREATE
        // =====================
        [HttpPost]
        public async Task<IActionResult> Create(UserCreate model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) ||
                string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest(new { message = "Username và Password không được rỗng" });
            }

            var user = new User
            {
                Username = model.Username,
                PasswordHash = model.Password, // tạm thời chưa hash
                FullName = model.FullName,
                Role = model.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Thêm user thành công",
                data = user
            });
        }

        // =====================
        // UPDATE
        // =====================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdate model)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound(new { message = "Không tìm thấy user" });

            user.Username = model.Username;
            user.FullName = model.FullName;
            user.Role = model.Role;

            // chỉ update password nếu có nhập
            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                user.PasswordHash = model.Password;
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Cập nhật thành công",
                data = user
            });
        }

        // =====================
        // DELETE
        // =====================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound(new { message = "Không tìm thấy user" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xoá thành công" });
        }
    }

    // =====================
    // DTO INLINE (GIỐNG CATEGORY STYLE)
    // =====================
    public class UserCreate
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }

    public class UserUpdate
    {
        public string Username { get; set; }
        public string Password { get; set; } // optional
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}