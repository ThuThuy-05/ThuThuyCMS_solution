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

        // DANH SÁCH CHI TIẾT ĐƠN HÀNG
        public IActionResult Index()
        {
            var orderDetails = _context.OrderDetails.ToList();

            return View(orderDetails);
        }

        // CHI TIẾT
        public IActionResult Details(int id)
        {
            var orderDetail = _context.OrderDetails.Find(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }
    }
}