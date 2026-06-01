### 🌿 Buổi 02: Kết Nối Cơ Sở Dữ Liệu Với Entity Framework Core (EF Core)

#### 🎯 Mục tiêu buổi học

Buổi học giúp tìm hiểu cách kết nối ứng dụng ASP.NET Core MVC với SQL Server thông qua Entity Framework Core (EF Core). Sau buổi học có thể tạo cơ sở dữ liệu từ các lớp C#, sử dụng Migration để quản lý Database và thay thế dữ liệu giả bằng dữ liệu thực tế.

---

#### 1️⃣ Cài đặt thư viện Entity Framework Core

Cài đặt các NuGet Package cần thiết cho dự án:

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

Các thư viện trên hỗ trợ:

- Kết nối SQL Server.
- Tạo và quản lý Migration.
- Thiết kế cơ sở dữ liệu theo phương pháp Code First.

---

#### 2️⃣ Tạo ApplicationDbContext

Tạo file **ApplicationDbContext.cs** trong project **CMS.Data**.

Sử dụng các đối tượng `DbSet<>` để ánh xạ Entity thành các bảng trong SQL Server:

- Categories
- Posts
- Users
- CategoriesProducts
- Products
- Customers
- Orders
- OrderDetails

---

#### 3️⃣ Cấu hình chuỗi kết nối (Connection String)

Thêm Connection String vào file **appsettings.json** trong project **CMS.Backend**.

Ví dụ:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=NONO\\THUTHUYR;Database=THUTHUYR_DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

Đối với SQL Server Express có thể sử dụng:

```text
(localdb)\mssqllocaldb
```

---

#### 4️⃣ Đăng ký DbContext trong Program.cs

Sử dụng Dependency Injection để đăng ký ApplicationDbContext:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
```

Điều này giúp hệ thống tự động quản lý kết nối Database.

---

#### 5️⃣ Thực hiện Migration

Mở Package Manager Console và thực hiện các lệnh:

```powershell
Add-Migration InitialCreate
Update-Database
```

Sau khi thực hiện thành công:

- Database được tạo tự động.
- Các bảng dữ liệu được sinh từ các Entity.

---

#### 6️⃣ Thay Dữ Liệu Giả Bằng Dữ Liệu Thật

Controller bắt đầu sử dụng ApplicationDbContext để truy xuất dữ liệu từ SQL Server.

Ví dụ:

```csharp
_context.Categories.ToList();
```

Dữ liệu hiển thị trên giao diện được lấy trực tiếp từ cơ sở dữ liệu thay vì Mock Data.

---

#### 7️⃣ Kiểm Tra Kết Quả

Sử dụng **SQL Server Management Studio 19 (SSMS)** để kiểm tra cơ sở dữ liệu.

Kiểm tra sự tồn tại của các bảng:

- Categories
- Posts
- Users
- CategoriesProducts
- Products
- Customers
- Orders
- OrderDetails

Nhập dữ liệu mẫu và kiểm tra khả năng hiển thị trên website.

---

#### 8️⃣ Bài Tập Thực Hành

Thực hiện xây dựng Controller và View cho các bảng:

- Post
- User
- CategoryProduct
- Product
- Customer
- Order
- OrderDetail

Yêu cầu:

- Kết nối dữ liệu thực từ SQL Server.
- Hiển thị danh sách dữ liệu trên giao diện MVC.

---

#### 📚 Kiến Thức Đạt Được

- Hiểu cách hoạt động của Entity Framework Core.
- Hiểu cơ chế Code First Migration.
- Biết cách kết nối SQL Server với ASP.NET Core MVC.
- Biết sử dụng ApplicationDbContext.
- Hiểu nguyên lý Dependency Injection.
- Truy xuất và hiển thị dữ liệu thực từ Database.

---

#### ✅ Kết Quả Đạt Được

Sau buổi học, hệ thống CMS đã kết nối thành công với SQL Server thông qua Entity Framework Core.

Database được tạo tự động bằng Migration, các bảng dữ liệu được sinh từ Entity và dữ liệu hiển thị trên giao diện được lấy trực tiếp từ cơ sở dữ liệu thay vì sử dụng dữ liệu giả.
