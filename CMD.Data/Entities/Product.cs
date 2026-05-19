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
        public int Id { get; set; } // id sản phẩm

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]// Validation: Bắt buộc phải nhập tên sản phẩm
        public string Name { get; set; } // Tên sản phẩm

        public string? Description { get; set; } // Mô tả sản phẩm

        [Range(0, double.MaxValue)]// Validation: Giá phải lớn hơn hoặc bằng 0
        [Column(TypeName = "decimal(18,2)")]// Định dạng kiểu dữ liệu decimal với 18 chữ số và 2 chữ số thập phân
        public decimal Price { get; set; } // Giá sản phẩm

        public int StockQuantity { get; set; } // Số lượng tồn kho

        public string? ImageUrl { get; set; } // Đường dẫn hình ảnh sản phẩm

        // Khóa ngoại nối tới CategoryProduct
        public int CategoryProductId { get; set; } // id danh mục sản phẩm, khóa ngoại liên kết với bảng CategoryProduct

        [ForeignKey("CategoryProductId")] // Khóa ngoại liên kết với bảng CategoryProduct
        public virtual CategoryProduct? CategoryProduct { get; set; } // Một sản phẩm thuộc về một danh mục sản phẩm
    }
}
