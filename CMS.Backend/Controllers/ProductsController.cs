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
using Microsoft.EntityFrameworkCore;

// Controller để quản lý sản phẩm
public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context; // Biến để truy cập dữ liệu từ cơ sở dữ liệu

    public ProductsController(ApplicationDbContext context)
    {
        _context = context; // Gán kết nối vào biến để sử dụng trong các phương thức của Controller
    }

    // Phương thức hiển thị danh sách sản phẩm
    public IActionResult Index()
    {
        var data = _context.Products
            .Include(x => x.CategoryProduct)
            .ToList();

        return View(data);
    }

    // GET
    [HttpGet]
    public IActionResult Create()
    {
        // Đổ dữ liệu CategoryProduct lên Combobox
        ViewBag.CategoryProductId = new SelectList(
            _context.CategoryProducts,
            "Id",
            "Name"
        );

        return View();
    }

    //POST
    [HttpPost]
    public IActionResult Create(Product model, IFormFile uploadImage)
    {
        if (uploadImage != null && uploadImage.Length > 0)
        {
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);

            string filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                uploadImage.CopyTo(stream);
            }

            model.ImageUrl = "/uploads/" + fileName;
        }

        _context.Products.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // =========================
    // SỬA
    // =========================

    // GET
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Tìm sản phẩm trong Database theo Id
        var product = _context.Products.Find(id);

        if (product == null)
            return NotFound();
        // Lấy danh sách CategoryProduct để hiển thị trong dropdown
        ViewBag.CategoryProductId = new SelectList(
            _context.CategoryProducts,
            "Id",
            "Name"
        );

        return View(product);
    }

    // POST
    [HttpPost]
    public IActionResult Edit(Product model, IFormFile uploadImage)
    {
        var product = _context.Products.Find(model.Id);

        if (product == null)
            return NotFound();

        product.Name = model.Name;
        product.Description = model.Description;
        product.Price = model.Price;
        product.StockQuantity = model.StockQuantity;
        product.CategoryProductId = model.CategoryProductId;

        if (uploadImage != null && uploadImage.Length > 0)
        {
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);

            string filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                uploadImage.CopyTo(stream);
            }

            product.ImageUrl = "/uploads/" + fileName;
        }

        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // =========================
    // XÓA
    // =========================
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);

        if (product != null)
        {
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

}