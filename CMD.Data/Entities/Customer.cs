/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/
using CMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    // Khách hàng
    public class Customer
    {
        [Key]
        public int Id { get; set; } // Khóa chính
        // id thông tin khách hàng

        [Required]
        public string FullName { get; set; } // Họ tên khách hàng

        [Required] // Ràng buộc bắt buộc nhập email
        [EmailAddress] // Ràng buộc định dạng email hợp lệ
        public string Email { get; set; } // Địa chỉ email khách hàng

        public string? Phone { get; set; } // Số điện thoại khách hàng

        public string? Address { get; set; } // Địa chỉ khách hàng

        [Required]
        public string Password { get; set; } // Lưu mật khẩu thô theo yêu cầu tối giản

        public virtual ICollection<Order>? Orders { get; set; }// Một khách hàng có nhiều đơn hàng
    }
}

