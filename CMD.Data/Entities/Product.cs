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
    public class Product
    {
        [Key]
        public int Id { get; set; } // Khóa chính, id sản phẩm

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]// Ràng buộc bắt buộc nhập tên sản phẩm
        public string Name { get; set; } // Tên sản phẩm

        public string? Description { get; set; } // Mô tả ngắn về sản phẩm (vd: Điện thoại iPhone 13 Pro Max, Laptop Dell XPS 15...)

        [Range(0, double.MaxValue)] // Ràng buộc giá phải lớn hơn hoặc bằng 0
        [Column(TypeName = "decimal(18,2)")]// Định nghĩa kiểu dữ liệu decimal với độ chính xác 18 và 2 chữ số thập phân
        public decimal Price { get; set; } // Giá sản phẩm

        public int StockQuantity { get; set; } // Số lượng tồn kho

        public string? ImageUrl { get; set; } // URL hình ảnh sản phẩm (vd: https://example.com/images/product1.jpg)

        // Khóa ngoại nối tới CategoryProduct
        public int CategoryProductId { get; set; } // id danh mục sản phẩm mà sản phẩm này thuộc về

        [ForeignKey("CategoryProductId")] // Chỉ định khóa ngoại nối tới CategoryProduct
        public virtual CategoryProduct? CategoryProduct { get; set; } // Một sản phẩm thuộc về một danh mục sản phẩm
    }
}
