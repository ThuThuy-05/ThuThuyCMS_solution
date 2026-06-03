using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // 1. CREATE ORDER
        // =========================
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderInputDTO input)
        {
            if (input == null)
            {
                return BadRequest(new { message = "Dữ liệu đơn hàng không hợp lệ" });
            }

            try
            {
                var newOrder = new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = input.CustomerId,
                    Status = 0,
                    Notes = input.Notes
                };

                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                return StatusCode(201, new
                {
                    message = "Đặt hàng thành công!",
                    orderId = newOrder.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi tạo đơn hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 2. GET ALL ORDERS
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _context.Orders
                    .OrderByDescending(o => o.OrderDate)
                    .ToListAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi lấy danh sách đơn hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 3. GET ORDER BY ID
        // =========================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    return NotFound(new { message = "Không tìm thấy đơn hàng" });
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi lấy chi tiết đơn hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 4. UPDATE ORDER
        // =========================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderUpdateDTO input)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    return NotFound(new { message = "Không tìm thấy đơn hàng" });
                }

                order.CustomerId = input.CustomerId;
                order.Notes = input.Notes;
                order.Status = input.Status;

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Cập nhật đơn hàng thành công",
                    orderId = order.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi cập nhật đơn hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 5. DELETE ORDER
        // =========================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    return NotFound(new { message = "Không tìm thấy đơn hàng" });
                }

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Xóa đơn hàng thành công"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi xóa đơn hàng",
                    detail = ex.Message
                });
            }
        }
    }

    // =========================
    // DTO CREATE
    // =========================
    public class OrderInputDTO
    {
        public int CustomerId { get; set; }
        public string Notes { get; set; }
    }

    // =========================
    // DTO UPDATE
    // =========================
    public class OrderUpdateDTO
    {
        public int CustomerId { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
    }
}