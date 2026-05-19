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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{
    public class Category
    {
        public int Id { get; set; } // id của danh mục
        public string Name { get; set; } // Tên danh mục (vd: Tin Giáo Dục)
        public string Description { get; set; } // Mô tả ngắn về danh mục (vd: Tin tức về giáo dục, trường học, học bổng...)

        // Quan hệ: Một danh mục có nhiều bài viết
        public virtual ICollection<Post> Posts { get; set; } // Một danh mục có nhiều sản phẩm
    }
}
