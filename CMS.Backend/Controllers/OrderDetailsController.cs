/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/


using CMS.Data;
using Microsoft.AspNetCore.Mvc;


// Controller để quản lý chi tiết đơn hàng
public class OrderDetailsController : Controller
{
    private readonly ApplicationDbContext _context; // Biến để truy cập dữ liệu từ cơ sở dữ liệu

    public OrderDetailsController(ApplicationDbContext context)
    {
        _context = context; // Gán kết nối vào biến để sử dụng trong các phương thức của Controller
    }

    public IActionResult Index()
    {
        var data = _context.OrderDetails.ToList(); // Truy vấn tất cả các chi tiết đơn hàng từ cơ sở dữ liệu và lưu vào biến data
        return View(data); // Trả về View và truyền dữ liệu chi tiết đơn hàng vào để hiển thị
    }
}