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
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult Create(User model)
        {
            // Kiểm tra username đã tồn tại chưa
            var checkExist = _context.Users.Any(u => u.Username == model.Username);

            if (checkExist)
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại!");
                return View(model);
            }

            // =========================
            // MÃ HÓA MẬT KHẨU
            // =========================
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);

            // Lưu database
            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        // =========================
        // SỬA USER
        // =========================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: Thực hiện lưu thay đổi
        [HttpPost]
        public IActionResult Edit(User model, string NewPassword)
        {
            var existingUser = _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == model.Id);

            if (existingUser == null)
                return NotFound();

            // =========================
            // NẾU CÓ NHẬP PASSWORD MỚI
            // =========================
            if (!string.IsNullOrEmpty(NewPassword))
            {
                // HASH PASSWORD MỚI
                model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(NewPassword);
            }
            else
            {
                // GIỮ PASSWORD CŨ
                model.PasswordHash = existingUser.PasswordHash;
            }

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