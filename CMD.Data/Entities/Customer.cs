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
        public int Id { get; set; } // id khách hàng    

        [Required] // Validation: Bắt buộc phải nhập họ tên khách hàng
        public string FullName { get; set; } // Họ tên khách hàng

        [Required] // Validation: Bắt buộc phải nhập email khách hàng
        [EmailAddress] // Validation: Định dạng email hợp lệ
        public string Email { get; set; } // Email khách hàng

        public string? Phone { get; set; } // Số điện thoại khách hàng

        public string? Address { get; set; } // Địa chỉ khách hàng

        [Required] // Validation: Bắt buộc phải nhập mật khẩu
        public string Password { get; set; } // Lưu mật khẩu thô theo yêu cầu tối giản

        public virtual ICollection<Order>? Orders { get; set; } // Một khách hàng có thể có nhiều đơn hàng
    }
}

