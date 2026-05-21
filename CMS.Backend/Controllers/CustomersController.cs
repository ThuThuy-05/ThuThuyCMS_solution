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

// Controller để quản lý khách hàng
public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context; // Biến để truy cập dữ liệu từ cơ sở dữ liệu

    public CustomersController(ApplicationDbContext context)
    {
        _context = context; // Gán kết nối vào biến để sử dụng trong các phương thức của Controller
    }

    // Phương thức hiển thị danh sách khách hàng
    public IActionResult Index()
    {
        var data = _context.Customers.ToList(); // Truy vấn tất cả các khách hàng từ cơ sở dữ liệu và lưu vào biến data
        return View(data); // Trả về View và truyền dữ liệu khách hàng vào để hiển thị
    }

    // GET
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST
    [HttpPost]
    public IActionResult Create(Customer model)
    {
        _context.Customers.Add(model);

        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // =========================
    // SỬA KHÁCH HÀNG
    // =========================

    // GET
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer == null)
            return NotFound();

        return View(customer);
    }

    // POST
    [HttpPost]
    public IActionResult Edit(Customer model, string NewPassword)
    {
        // Tìm dữ liệu cũ trong database
        var customer = _context.Customers.Find(model.Id);

        if (customer == null)
            return NotFound();

        // Cập nhật dữ liệu
        customer.FullName = model.FullName;
        customer.Email = model.Email;
        customer.Phone = model.Phone;
        customer.Address = model.Address;

        // Nếu nhập mật khẩu mới thì mới đổi
        if (!string.IsNullOrEmpty(NewPassword))
        {
            customer.Password = NewPassword;
        }

        // Lưu xuống SQL
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // =========================
    // XÓA KHÁCH HÀNG
    // =========================
    public IActionResult Delete(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer != null)
        {
            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}