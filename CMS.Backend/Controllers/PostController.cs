/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/

using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using CMS.Data;

namespace CMS.Backend.Controllers
{
    // Controller để quản lý bài viết
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context; // Biến để truy cập dữ liệu từ cơ sở dữ liệu

        public PostController(ApplicationDbContext context)
        {
            _context = context; // Gán kết nối vào biến để sử dụng trong các phương thức của Controller
        }

        // Danh sách bài viết
        public IActionResult Index()
        {
            var posts = _context.Posts.ToList(); // Truy vấn tất cả các bài viết từ cơ sở dữ liệu và lưu vào biến posts
            return View(posts); // Trả về View và truyền dữ liệu bài viết vào để hiển thị
        }

        // Chi tiết bài viết
        public IActionResult Details(int id)
        {
            var post = _context.Posts.Find(id); // Tìm bài viết theo id đã cho từ cơ sở dữ liệu và lưu vào biến post

            if (post == null)
                return NotFound(); // Nếu không tìm thấy bài viết với id đã cho, trả về lỗi NotFound

            return View(post); // Trả về View và truyền dữ liệu bài viết vào để hiển thị chi tiết
        }
    }
}