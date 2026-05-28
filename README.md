BUỔI 2: KẾT NỐI CƠ SỞ DỮ LIỆU VỚI ENTITY FRAMEWORK CORE (EF CORE).

1. Mục tiêu buổi học
Buổi học giúp mình hiểu cách kết nối ASP.NET Core MVC với SQL Server bằng Entity Framework Core.
 Sau buổi này có thể tạo Database thật từ các class C#, sử dụng Migration để quản lý dữ liệu và thay thế dữ liệu giả bằng dữ liệu thật.
3. Cài đặt thư viện EF Core
Cài đặt các NuGet Package cần thiết cho CMS.Data và CMS.Backend gồm:
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
Các thư viện này hỗ trợ kết nối SQL Server, tạo Migration và thiết kế Database.
3. Tạo ApplicationDbContext
Tạo file ApplicationDbContext.cs trong project CMS.Data để quản lý kết nối Database.
Sử dụng DbSet để ánh xạ các Entity thành bảng SQL như:
Categories, Posts, Users, CategoriesProducts, Products, Customers, Orders, OrderDetails.
4. Cấu hình chuỗi kết nối
Thêm Connection String vào file appsettings.json trong CMS.Backend.
Ví dụ:
"Server=NONO\\THUTHUYR;Database=THUTHUYR_DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
Nếu dùng SQL Express có thể dùng:
(localdb)\\mssqllocaldb
5. Đăng ký DbContext trong Program.cs
Sử dụng builder.Services.AddDbContext<ApplicationDbContext>() để hệ thống tự động kết nối Database bằng Dependency Injection.
6. Thực hiện Migration
Mở Package Manager Console và chạy:
- Add-Migration InitialCreate
- Update-Database
Sau khi chạy thành công, SQL Server sẽ tự động tạo Database và các bảng.
7. Thay dữ liệu giả bằng dữ liệu thật
Controller sử dụng ApplicationDbContext để lấy dữ liệu từ Database.
Ví dụ:
_context.Categories.ToList();
Dữ liệu hiển thị trên giao diện sẽ lấy trực tiếp từ SQL Server.
8. Kiểm tra kết quả
Mở SSMS để kiểm tra Database ThuyCMS_DB.
Kiểm tra đủ 8 bảng dữ liệu:
Categories, Posts, Users, CategoriesProducts, Products, Customers, Orders, OrderDetails.
Nhập dữ liệu mẫu và chạy website để kiểm tra hiển thị.
9. Bài tập thực hành
Thực hành tạo Controller và View cho các bảng:
- Post
- User
- CategoryProduct
- Product
- Customer
- Order
- OrderDetail
Sử dụng dữ liệu thật từ Database để hiển thị danh sách.
10. Kiến thức đạt được
Hiểu cách hoạt động của Entity Framework Core.
Biết cách tạo Database bằng Code First Migration.
Biết kết nối SQL Server với ASP.NET Core MVC.
Biết sử dụng Dependency Injection và DbContext để truy xuất dữ liệu thật.
