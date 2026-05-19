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
        public int Id { get; set; } // Khóa chính,Tên danh mục sản phẩm


        [Required(ErrorMessage = "Tên danh mục không được để trống")] // Ràng buộc bắt buộc nhập tên danh mục
        [StringLength(100)] // Ràng buộc độ dài tối đa của tên danh mục là 100 ký tự
        public string Name { get; set; } // Tên danh mục sản phẩm (vd: Điện tử, Thời trang, Gia dụng...)

        public string? Description { get; set; } // Mô tả ngắn về danh mục sản phẩm (vd: Các sản phẩm điện tử như điện thoại, laptop, tivi...)

        // Quan hệ: Một danh mục có nhiều sản phẩm
        public virtual ICollection<Product>? Products { get; set; } // Một danh mục có nhiều sản phẩm
    }
}
