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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; } // id đơn hàng

        public DateTime OrderDate { get; set; } = DateTime.Now; // Ngày đặt hàng, mặc định là ngày hiện tại

        public int CustomerId { get; set; } // id khách hàng, khóa ngoại liên kết với bảng Customer

        public int Status { get; set; } // 0: Chờ duyệt, 1: Đang giao, 2: Đã xong

        public string? Notes { get; set; } // Ghi chú thêm về đơn hàng (vd: Yêu cầu giao hàng nhanh, Giao hàng vào buổi tối...)

        [ForeignKey("CustomerId")] // Khóa ngoại liên kết với bảng Customer
        public virtual Customer? Customer { get; set; } // Một đơn hàng thuộc về một khách hàng

        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } // Một đơn hàng có nhiều chi tiết đơn hàng (OrderDetail)
    }
}
