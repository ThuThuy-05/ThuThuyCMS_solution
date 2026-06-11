/*
 * Sinh vien: Nguyen Thi Thu Thuy
 * Ma sv: 2123110071
 * Ngay tao: 14-05-2026
 * Version: 1.0
 */

using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Backend.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // DANH SÁCH USER
        // =========================
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // =========================
        // THÊM USER
        // =========================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra Username đã tồn tại chưa
            var checkExist = _context.Users.Any(u => u.Username == model.Username);

            if (checkExist)
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại!");
                return View(model);
            }

            // Lưu trực tiếp mật khẩu (KHÔNG HASH)
            _context.Users.Add(model);
            _context.SaveChanges();

            TempData["success"] = "Thêm người dùng thành công!";
            return RedirectToAction("Index");
        }

        // =========================
        // SỬA USER
        // =========================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User model, string NewPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == model.Id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Kiểm tra Username bị trùng với user khác
            var checkExist = _context.Users.Any(u =>
                u.Username == model.Username &&
                u.Id != model.Id);

            if (checkExist)
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại!");
                return View(model);
            }

            // Nếu nhập mật khẩu mới
            if (!string.IsNullOrEmpty(NewPassword))
            {
                model.PasswordHash = NewPassword;
            }
            else
            {
                // Giữ mật khẩu cũ
                model.PasswordHash = existingUser.PasswordHash;
            }

            _context.Users.Update(model);
            _context.SaveChanges();

            TempData["success"] = "Cập nhật người dùng thành công!";
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

                TempData["success"] = "Xóa người dùng thành công!";
            }

            return RedirectToAction("Index");
        }
    }
}