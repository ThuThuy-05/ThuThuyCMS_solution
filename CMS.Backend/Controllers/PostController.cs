/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/

using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        // GET
        [HttpGet]
        public IActionResult Create()
        {
            // Đổ dữ liệu Category lên Combobox
            ViewBag.CategoryId = new SelectList(
                _context.Categories,
                "Id",
                "Name"
            );

            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(Post model)
        {
            // Thêm dữ liệu vào bộ nhớ tạm
            _context.Posts.Add(model);

            // Lưu dữ liệu xuống SQL Server
            _context.SaveChanges();

            // Quay về danh sách
            return RedirectToAction("Index");
        }

        // ============================
        // SỬA BÀI VIẾT
        // ============================

        // GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.Find(id);

            if (post == null)
                return NotFound();

            // Đổ Category lên Combobox
            ViewBag.CategoryId = new SelectList(
                _context.Categories,
                "Id",
                "Name"
            );

            return View(post);
        }

        // POST
        [HttpPost]
        public IActionResult Edit(Post model)
        {
            // Cập nhật dữ liệu
            _context.Posts.Update(model);

            // Lưu xuống SQL Server
            _context.SaveChanges();

            // Quay về danh sách
            return RedirectToAction("Index");
        }

        // ============================
        // XÓA BÀI VIẾT
        // ============================
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.Find(id);

            if (post != null)
            {
                // Xóa bài viết
                _context.Posts.Remove(post);

                // Lưu thay đổi
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}