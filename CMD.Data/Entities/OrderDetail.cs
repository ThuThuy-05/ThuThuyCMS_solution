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
        public int Id { get; set; } // Khóa chính, id chi tiết đơn hàng

        public int OrderId { get; set; } // Khóa ngoại nối tới Order, id đơn hàng

        public int ProductId { get; set; } // Khóa ngoại nối tới Product, id sản phẩm

        public int Quantity { get; set; } // Số lượng sản phẩm trong đơn hàng

        [Column(TypeName = "decimal(18,2)")] // Định nghĩa kiểu dữ liệu decimal với độ chính xác 18 và 2 chữ số thập phân
        public decimal UnitPrice { get; set; } // Giá tại thời điểm mua

        [ForeignKey("OrderId")] // Chỉ định khóa ngoại nối tới Order
        public virtual Order? Order { get; set; } // Một chi tiết đơn hàng thuộc về một đơn hàng

        [ForeignKey("ProductId")] // Chỉ định khóa ngoại nối tới Product
        public virtual Product? Product { get; set; } // Một chi tiết đơn hàng thuộc về một sản phẩm
    }
}
