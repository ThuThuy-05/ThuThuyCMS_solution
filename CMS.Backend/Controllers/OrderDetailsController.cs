/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/

using CMS.Data;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    // Controller để quản lý chi tiết đơn hàng
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Xem chi tiết theo mã đơn hàng
        public IActionResult Index(int id)
        {
            // Lấy các sản phẩm thuộc đơn hàng
            var data = _context.OrderDetails
                        .Where(x => x.OrderId == id)
                        .ToList();
            // Trả dữ liệu sang View
            return View(data);
        }
    }
}