/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/

using CMS.Data;
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
}