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

namespace CMS.Backend.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // DANH SÁCH USER
        public IActionResult Index()
        {
            var users = _context.Users.ToList();

            return View(users);
        }

        // =========================
        // THÊM USER
        // =========================

        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(User model)
        {
            // Kiểm tra dữ liệu hợp lệ
            _context.Users.Add(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // SỬA USER
        // =========================

        // GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Tìm user theo id
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST
        [HttpPost]
        // Cập nhật thông tin user
        public IActionResult Edit(User model)
        {
            _context.Users.Update(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // XÓA USER
        // =========================

        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}