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
        var data = _context.Products.ToList(); // Truy vấn tất cả các sản phẩm từ cơ sở dữ liệu và lưu vào biến data    
        return View(data); // Trả về View và truyền dữ liệu sản phẩm vào để hiển thị
    }


    // GET
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.CategoryProductId = new SelectList(
            _context.CategoryProducts,
            "Id",
            "Name"
        );

        return View();
    }

    // POST
    [HttpPost]
    public IActionResult Create(Product model)
    {
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
        var product = _context.Products.Find(id);

        if (product == null)
            return NotFound();

        ViewBag.CategoryProductId = new SelectList(
            _context.CategoryProducts,
            "Id",
            "Name"
        );

        return View(product);
    }

    // POST
    [HttpPost]
    public IActionResult Edit(Product model)
    {
        var product = _context.Products.Find(model.Id);

        if (product == null)
            return NotFound();

        product.Name = model.Name;
        product.Description = model.Description;
        product.Price = model.Price;
        product.StockQuantity = model.StockQuantity;
        product.ImageUrl = model.ImageUrl;
        product.CategoryProductId = model.CategoryProductId;

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