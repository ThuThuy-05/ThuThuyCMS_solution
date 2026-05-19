/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/

using CMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor nhận DbContextOptions để cấu hình kết nối cơ sở dữ liệu
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } // DbSet cho bảng Categories, đại diện cho tập hợp các đối tượng Category trong cơ sở dữ liệu
        public DbSet<Post> Posts { get; set; } //   DbSet cho bảng Posts, đại diện cho tập hợp các đối tượng Post trong cơ sở dữ liệu
        public DbSet<User> Users { get; set; } // DbSet cho bảng Users, đại diện cho tập hợp các đối tượng User trong cơ sở dữ liệu
        public DbSet<CategoryProduct> CategoryProducts { get; set; } // DbSet cho bảng CategoryProducts, đại diện cho tập hợp các đối tượng CategoryProduct trong cơ sở dữ liệu
        public DbSet<Product> Products { get; set; } // DbSet cho bảng Products, đại diện cho tập hợp các đối tượng Product trong cơ sở dữ liệu
        public DbSet<Customer> Customers { get; set; } // DbSet cho bảng Customers, đại diện cho tập hợp các đối tượng Customer trong cơ sở dữ liệu
        public DbSet<Order> Orders { get; set; } // DbSet cho bảng Orders, đại diện cho tập hợp các đối tượng Order trong cơ sở dữ liệu
        public DbSet<OrderDetail> OrderDetails { get; set; } // DbSet cho bảng OrderDetails, đại diện cho tập hợp các đối tượng OrderDetail trong cơ sở dữ liệu
    }
}