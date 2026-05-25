/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 21-05-2026
*Version: 1.0
*
*/

using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class CategoryProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // DANH SÁCH
        public IActionResult Index()
        {
            var data = _context.CategoryProducts.ToList();

            return View(data);
        }

        // =========================
        // THÊM
        // =========================

        [HttpGet]
        // Hiển thị form để thêm mới một danh mục sản phẩm
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // Thêm mới một danh mục sản phẩm vào cơ sở dữ liệu
        public IActionResult Create(CategoryProduct model)
        {
            _context.CategoryProducts.Add(model); 

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // SỬA
        // =========================

        [HttpGet]
        // Hiển thị form để chỉnh sửa một danh mục sản phẩm dựa trên id
        public IActionResult Edit(int id)
        {
            var category = _context.CategoryProducts.Find(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        // Cập nhật thông tin của một danh mục sản phẩm đã tồn tại trong cơ sở dữ liệu
        public IActionResult Edit(CategoryProduct model)
        {
            _context.CategoryProducts.Update(model);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // XÓA
        // =========================
        // Xóa một danh mục sản phẩm khỏi cơ sở dữ liệu dựa trên id
        public IActionResult Delete(int id)
        {
            var category = _context.CategoryProducts.Find(id);

            if (category != null)
            {
                _context.CategoryProducts.Remove(category);

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}