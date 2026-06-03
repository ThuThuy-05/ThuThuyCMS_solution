using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // 1. GET ALL CUSTOMERS (FIX CYCLE)
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _context.Customers
                    .Select(c => new
                    {
                        c.Id,
                        c.FullName,
                        c.Email,
                        c.Phone,
                        c.Address
                    })
                    .ToListAsync();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi lấy danh sách khách hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 2. GET BY ID (FIX CYCLE)
        // =========================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _context.Customers
                    .Where(c => c.Id == id)
                    .Select(c => new
                    {
                        c.Id,
                        c.FullName,
                        c.Email,
                        c.Phone,
                        c.Address,
                        Orders = c.Orders.Select(o => new
                        {
                            o.Id,
                            o.OrderDate,
                            o.Status,
                            o.Notes
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (customer == null)
                {
                    return NotFound(new { message = "Không tìm thấy khách hàng" });
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi lấy chi tiết khách hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 3. CREATE (GIỮ NGUYÊN)
        // =========================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDTO input)
        {
            if (input == null)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });
            }

            try
            {
                var customer = new Customer
                {
                    FullName = input.FullName,
                    Email = input.Email,
                    Phone = input.Phone,
                    Address = input.Address,
                    Password = input.Password
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return StatusCode(201, new
                {
                    message = "Tạo khách hàng thành công",
                    customerId = customer.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi tạo khách hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 4. UPDATE (GIỮ NGUYÊN)
        // =========================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDTO input)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound(new { message = "Không tìm thấy khách hàng" });
                }

                customer.FullName = input.FullName;
                customer.Email = input.Email;
                customer.Phone = input.Phone;
                customer.Address = input.Address;
                customer.Password = input.Password;

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Cập nhật khách hàng thành công",
                    customerId = customer.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi cập nhật khách hàng",
                    detail = ex.Message
                });
            }
        }

        // =========================
        // 5. DELETE (GIỮ NGUYÊN)
        // =========================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound(new { message = "Không tìm thấy khách hàng" });
                }

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Xóa khách hàng thành công"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Lỗi xóa khách hàng",
                    detail = ex.Message
                });
            }
        }
    }

    // DTO giữ nguyên
    public class CustomerDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
    }
}