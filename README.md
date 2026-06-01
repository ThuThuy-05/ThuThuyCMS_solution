# 📘 HỆ THỐNG QUẢN LÝ NỘI DUNG WEBSITE (CMS)

### Đồ án môn Chuyên Đề ASP.NET Core

---

## 👤 SINH VIÊN THỰC HIỆN
- **Họ và tên:** Nguyễn Thị Thu Thủy
- **Mã số sinh viên:** 2123110071
- **Môn học:** Chuyên Đề ASP.NET Core
- **Giảng viên hướng dẫn:** ThS. Nguyễn Cao Thái
- **Trường:** Cao đẳng Công Thương Thành phố Hồ Chí Minh
- **Năm học:** 2026 - **Công nghệ sử dụng:** ASP.NET Core MVC, Entity Framework Core, SQL Server,.. ---

## 📖 GIỚI THIỆU ĐỀ TÀI

Hệ thống Quản lý Nội dung Website (Content Management System - CMS) được xây dựng nhằm hỗ trợ quản trị viên quản lý nội dung website một cách trực quan, hiệu quả và dễ dàng.

Đề tài được phát triển bằng nền tảng ASP.NET Core MVC kết hợp Entity Framework Core và SQL Server, áp dụng mô hình MVC trong xây dựng ứng dụng Web hiện đại. Ngoài ra, hệ thống còn tích hợp Swagger/OpenAPI để hỗ trợ kiểm thử và tài liệu hóa các API.

Hệ thống cho phép quản lý nhiều đối tượng dữ liệu khác nhau như danh mục, bài viết, sản phẩm, khách hàng, đơn hàng và người dùng.

---

## 🎯 MỤC TIÊU ĐỀ TÀI

- Tìm hiểu mô hình MVC trong ASP.NET Core.
- Xây dựng ứng dụng Web kết nối cơ sở dữ liệu SQL Server.
- Áp dụng Entity Framework Core theo phương pháp Code First.
- Xây dựng và quản lý cơ sở dữ liệu bằng Migration.
- Thực hiện đầy đủ các chức năng CRUD.
- Áp dụng LINQ trong truy vấn dữ liệu.
- Xây dựng và kiểm thử API bằng Swagger.
- Nâng cao kỹ năng phát triển ứng dụng Web bằng ngôn ngữ C#.

---

## 🛠️ CÔNG NGHỆ SỬ DỤNG

| Công nghệ | Mô tả |
|------------|------------|
| Visual Studio 2022 | Môi trường phát triển |
| ASP.NET Core MVC | Xây dựng ứng dụng Web |
| ASP.NET Core Web API | Xây dựng API |
| Swagger / OpenAPI | Kiểm thử và tài liệu hóa API |
| C# | Ngôn ngữ lập trình |
| Entity Framework Core | ORM |
| SQL Server | Hệ quản trị cơ sở dữ liệu |
| SQL Server Management Studio 19 | Quản lý cơ sở dữ liệu |
| LINQ | Truy vấn dữ liệu |
| Razor View Engine | Xây dựng giao diện |
| Bootstrap | Thiết kế giao diện |

---

## 🏗️ KIẾN TRÚC HỆ THỐNG

Dự án được xây dựng theo mô hình MVC (Model - View - Controller).

### Model

Quản lý dữ liệu và thao tác với cơ sở dữ liệu thông qua Entity Framework Core.

### View

Hiển thị giao diện người dùng bằng Razor View kết hợp Bootstrap.

### Controller

Tiếp nhận yêu cầu từ người dùng, xử lý nghiệp vụ và trả kết quả cho View.

---

## 🔗 API VÀ SWAGGER

Hệ thống tích hợp Swagger/OpenAPI nhằm hỗ trợ quá trình phát triển và kiểm thử API.

Các chức năng chính:

- Xem danh sách dữ liệu.
- Thêm dữ liệu mới.
- Cập nhật dữ liệu.
- Xóa dữ liệu.
- Kiểm thử API trực tiếp trên trình duyệt.
- Theo dõi phản hồi và trạng thái API.

Swagger giúp đơn giản hóa quá trình phát triển, kiểm thử và bảo trì hệ thống.

---

## 📂 CẤU TRÚC DỰ ÁN

```text
ThuThuyCMS_Solution
│
├── CMS.Backend
│   ├── Controllers
│   │   ├── AccountController
│   │   ├── CategoryController
│   │   ├── CategoryProductController
│   │   ├── CustomersController
│   │   ├── HomeController
│   │   ├── OrderDetailsController
│   │   ├── OrdersController
│   │   ├── PostController
│   │   ├── PostsController
│   │   ├── ProductsController
│   │   └── UserController
│   │
│   ├── Models
│   ├── Views
│   ├── wwwroot
│   ├── appsettings.json
│   └── Program.cs
│
├── CMS.Data
│   ├── Entities
│   │   ├── Category
│   │   ├── CategoryProduct
│   │   ├── Customer
│   │   ├── Order
│   │   ├── OrderDetail
│   │   ├── Post
│   │   ├── Product
│   │   └── User
│   │
│   ├── Migrations
│   └── ApplicationDbContext.cs
│
└── cms.frontend
```

---

## ✨ CHỨC NĂNG HỆ THỐNG

### 📁 Quản Lý Danh Mục (Category)

- Hiển thị danh sách danh mục.
- Thêm danh mục mới.
- Chỉnh sửa danh mục.
- Xóa danh mục.

### 📰 Quản Lý Bài Viết (Post)

- Hiển thị danh sách bài viết.
- Thêm bài viết mới.
- Chỉnh sửa bài viết.
- Xóa bài viết.

### 🛒 Quản Lý Sản Phẩm (Product)

- Hiển thị danh sách sản phẩm.
- Thêm sản phẩm mới.
- Chỉnh sửa sản phẩm.
- Xóa sản phẩm.

### 📦 Quản Lý Danh Mục Sản Phẩm (CategoryProduct)

- Quản lý nhóm sản phẩm.
- Phân loại sản phẩm.

### 👤 Quản Lý Người Dùng (User)

- Quản lý thông tin người dùng.
- Cập nhật dữ liệu người dùng.

### 👥 Quản Lý Khách Hàng (Customer)

- Thêm khách hàng.
- Chỉnh sửa khách hàng.
- Xóa khách hàng.

### 📦 Quản Lý Đơn Hàng (Order)

- Theo dõi đơn hàng.
- Quản lý trạng thái đơn hàng.

### 📄 Quản Lý Chi Tiết Đơn Hàng (OrderDetail)

- Xem chi tiết đơn hàng.
- Quản lý sản phẩm trong đơn hàng.

---

## 🗄️ CƠ SỞ DỮ LIỆU

Hệ thống sử dụng SQL Server kết hợp Entity Framework Core theo phương pháp Code First.

### Các bảng dữ liệu chính

- Categories
- Posts
- Products
- CategoryProducts
- Customers
- Orders
- OrderDetails
- Users

Quan hệ dữ liệu được quản lý thông qua Entity Framework Core và ApplicationDbContext.

---

## 📸 HÌNH ẢNH DỰ ÁN

Hình ảnh giao diện và các chức năng của hệ thống sẽ được cập nhật trong các phiên bản tiếp theo.

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT

### Clone Source Code

```bash
git clone https://github.com/ThuThuy-05/ThuThuyCMS_solution.git
```

### Khôi phục Package

```bash
dotnet restore
```

### Tạo Database

```powershell
Add-Migration InitialCreate

Update-Database
```

### Chạy Dự Án

```bash
dotnet run
```

### Truy Cập Swagger

```text
https://localhost:{port}/swagger
```

---

## 📚 KẾT QUẢ ĐẠT ĐƯỢC

- Xây dựng thành công hệ thống CMS bằng ASP.NET Core MVC.
- Kết nối SQL Server bằng Entity Framework Core.
- Hoàn thiện chức năng CRUD cho nhiều đối tượng dữ liệu.
- Xây dựng và kiểm thử API bằng Swagger/OpenAPI.
- Áp dụng LINQ trong truy vấn dữ liệu.
- Thực hiện Migration quản lý cơ sở dữ liệu.
- Nắm vững mô hình MVC trong phát triển ứng dụng Web.
- Nâng cao kỹ năng lập trình C# và quản lý dữ liệu.

---

## 📄 MỤC ĐÍCH

Dự án được thực hiện nhằm phục vụ học tập, nghiên cứu và thực hành phát triển ứng dụng Web bằng ASP.NET Core MVC, đồng thời giúp sinh viên tiếp cận quy trình xây dựng một hệ thống quản lý nội dung hoàn chỉnh từ thiết kế cơ sở dữ liệu đến triển khai ứng dụng.
