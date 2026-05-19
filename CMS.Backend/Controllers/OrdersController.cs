/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/

using CMS.Data;
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
}