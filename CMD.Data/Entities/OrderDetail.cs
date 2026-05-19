/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; } // id chi tiết đơn hàng 

        public int OrderId { get; set; } // id đơn hàng, khóa ngoại liên kết với bảng Order

        public int ProductId { get; set; } // id sản phẩm, khóa ngoại liên kết với bảng Product

        public int Quantity { get; set; } // Số lượng sản phẩm

        [Column(TypeName = "decimal(18,2)")]// Định dạng kiểu dữ liệu decimal với 18 chữ số và 2 chữ số thập phân
        public decimal UnitPrice { get; set; } // Giá tại thời điểm mua

        [ForeignKey("OrderId")]// Khóa ngoại liên kết với bảng Order
        public virtual Order? Order { get; set; } // Một chi tiết đơn hàng thuộc về một đơn hàng

        [ForeignKey("ProductId")] // Khóa ngoại liên kết với bảng Product
        public virtual Product? Product { get; set; } // Một chi tiết đơn hàng liên kết với một sản phẩm
    }
}
