/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/

using CMS.Data.Entities; // Kết nối tới lớp dữ liệu bạn vừa tạo
using Microsoft.AspNetCore.Mvc;
using CMS.Data;

// Controller để quản lý danh mục sản phẩm
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context; // Biến để truy cập dữ liệu từ cơ sở dữ liệu

    // "Tiêm" kết nối vào Controller
    public CategoryController(ApplicationDbContext context)
    {
        _context = context; // Gán kết nối vào biến để sử dụng trong các phương thức của Controller
    }

    // Phương thức hiển thị danh sách danh mục sản phẩm
    public IActionResult Index()
    {
        // Lấy dữ liệu THẬT từ bảng Categories trong SQL
        var data = _context.Categories.ToList(); // Truy vấn tất cả các danh mục sản phẩm từ cơ sở dữ liệu và lưu vào biến data
        return View(data); // Trả về View và truyền dữ liệu danh mục sản phẩm vào để hiển thị
    }
}
