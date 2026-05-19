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
    public class User
    {
        public int Id { get; set; } // Khóa chính, id người dùng
        public string Username { get; set; } // Tên đăng nhập
        public string PasswordHash { get; set; } // Mã băm mật khẩu
        public string FullName { get; set; } // Họ và tên
        public string Role { get; set; } // Quản trị viên hoặc Biên tập viên
    }
}
