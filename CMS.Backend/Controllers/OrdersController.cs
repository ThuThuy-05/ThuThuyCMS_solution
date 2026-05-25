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


// Controller để quản lý đơn hàng
public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context; // Gán kết nối vào biến để sử dụng trong các phương thức của Controller
    }

    // Phương thức hiển thị danh sách đơn hàng
    public IActionResult Index()
    {
        var data = _context.Orders.ToList(); // Truy vấn tất cả các đơn hàng từ cơ sở dữ liệu và lưu vào biến data
        return View(data); // Trả về View và truyền dữ liệu đơn hàng vào để hiển thị
    }

    // =========================
    // CẬP NHẬT TRẠNG THÁI
    // =========================

    // GET
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost]
    public IActionResult Edit(Order model)
    {
        // Tìm đơn hàng theo id
        var order = _context.Orders.Find(model.Id);

        // Nếu tồn tại dữ liệu
        if (order != null)
        {
            // Cập nhật trạng thái
            order.Status = model.Status;

            // Cập nhật ghi chú
            order.Notes = model.Notes;

            // Lưu xuống database
            _context.SaveChanges();
        }

        // Quay về danh sách
        return RedirectToAction("Index");
    }
}