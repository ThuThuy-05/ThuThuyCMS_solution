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

namespace CMS.Data.Entities
{
    public class Post
    {
        public int Id { get; set; } // id bài viết
        public string Title { get; set; } // Tiêu đề bài viết
        public string Content { get; set; } // Nội dung chi tiết
        public string ImageUrl { get; set; } // Hình ảnh đại diện
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Ngày tạo, mặc định là ngày hiện tại

        // Khóa ngoại liên kết tới Category
        public int CategoryId { get; set; } // id danh mục, khóa ngoại liên kết với bảng Category
        public virtual Category Category { get; set; } // Một bài viết thuộc về một danh mục
    }
}
