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
namespace CMS.Data.Entities
{

    public class CategoryProduct
    {
        [Key]
        public int Id { get; set; } // id danh mục sản phẩm

        [Required(ErrorMessage = "Tên danh mục không được để trống")] // Validation: Bắt buộc phải nhập tên danh mục
        [StringLength(100)] // Validation: Giới hạn độ dài tên danh mục tối đa 100 ký tự
        public string Name { get; set; } // Tên danh mục sản phẩm (vd: Điện tử, Thời trang...)

        public string? Description { get; set; } // Mô tả ngắn về danh mục sản phẩm (vd: Các sản phẩm điện tử như laptop, điện thoại...)

        // Quan hệ: Một danh mục có nhiều sản phẩm
        public virtual ICollection<Product>? Products { get; set; } // Một danh mục có nhiều sản phẩm
    }
}
