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

    // Hàm tạo
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // 2. Hàm POST: Dùng để đón dữ liệu từ Form gửi lên và lưu vào SQL
    [HttpPost]
    public IActionResult Create(Category model)
    {
        // BƯỚC 1: Thêm dữ liệu vào bộ nhớ tạm của Entity Framework
        _context.Categories.Add(model);

        // BƯỚC 2: Ra lệnh cho hệ thống ghi dữ liệu thật sự vào SQL Server
        _context.SaveChanges();

        // Sau khi lưu thành công, tự động quay về trang danh sách
        return RedirectToAction("Index");
    }

    // Ham edit
    // 1. Hàm GET: Tìm dữ liệu cũ và đổ lên Form
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Tìm danh mục trong Database theo Id [cite: 348, 350]
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound();

        return View(category); // Gửi đối tượng tìm được sang giao diện Edit
    }

    // 2. Hàm POST: Nhận dữ liệu mới từ người dùng và lưu lại
    [HttpPost]
    public IActionResult Edit(Category model)
    {
        // Lệnh cập nhật đối tượng vào bộ nhớ tạm
        _context.Categories.Update(model);

        // Lưu thay đổi thực sự xuống SQL Server [cite: 504, 509]
        _context.SaveChanges();

        // Quay lại trang danh sách để xem kết quả
        return RedirectToAction("Index");
    }

    // Ham xoa
    public IActionResult Delete(int id)
    {
        // Bước 1: Tìm đối tượng danh mục trong Database bằng Id
        var category = _context.Categories.Find(id);

        // Kiểm tra nếu tìm thấy thì mới xóa
        if (category != null)
        {
            // Bước 2: Lệnh xóa khỏi bộ nhớ tạm (Tracking)
            _context.Categories.Remove(category);

            // Bước 3: Chốt phiên làm việc, xóa thực sự trong SQL Server
            _context.SaveChanges();
        }

        // Sau khi xóa xong, quay lại trang danh sách để cập nhật giao diện
        return RedirectToAction("Index");
    }

}
