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
        // 6. GET ORDERS BY CUSTOMER
        // =========================
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            try
            {
                var orders = await _context.Orders
                    .Where(o => o.CustomerId == customerId)
                    .OrderByDescending(o => o.OrderDate)
                    .ToListAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi lấy đơn hàng theo khách hàng",
                    detail = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderInputDTO input)
        {
            if (input == null || input.Items == null || !input.Items.Any())
            {
                return BadRequest(new { message = "Dữ liệu đơn hàng không hợp lệ" });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // =====================
                // 1. Tạo Order
                // =====================
                var order = new Order
                {
                    CustomerId = input.CustomerId,
                    Notes = input.Notes,
                    OrderDate = DateTime.Now,
                    Status = 0
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // =====================
                // 2. Duyệt giỏ hàng
                // =====================
                foreach (var item in input.Items)
                {
                    var product = await _context.Products
                        .FirstOrDefaultAsync(p => p.Id == item.ProductId);

                    if (product == null)
                    {
                        throw new Exception($"Sản phẩm {item.ProductId} không tồn tại");
                    }

                    // Check tồn kho
                    if (product.StockQuantity < item.Quantity)
                    {
                        throw new Exception($"Sản phẩm {product.Name} không đủ hàng");
                    }

                    // =====================
                    // 3. Tạo OrderDetail
                    // =====================
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price
                    };

                    _context.OrderDetails.Add(orderDetail);

                    // =====================
                    // 4. Trừ kho
                    // =====================
                    product.StockQuantity -= item.Quantity;

                    _context.Products.Update(product);
                }

                // =====================
                // 5. Save all
                // =====================
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return StatusCode(201, new
                {
                    message = "Đặt hàng thành công",
                    orderId = order.Id
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return StatusCode(500, new
                {
                    message = "Đặt hàng thất bại",
                    detail = ex.Message
                });
            }
        }

        public class OrderInputDTO
        {
            public int CustomerId { get; set; }
            public string Notes { get; set; }

            public List<OrderItemDTO> Items { get; set; }
        }

        public class OrderItemDTO
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

    }
}