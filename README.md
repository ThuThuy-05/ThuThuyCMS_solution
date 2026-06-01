# 📘 ĐỒ ÁN MÔN CHUYÊN ĐỀ ASP.NET CORE

# HỆ THỐNG QUẢN LÝ NỘI DUNG WEBSITE (CMS)

---

## 👤 SINH VIÊN THỰC HIỆN

- **Họ và tên:** Nguyễn Thị Thu Thủy
- **Mã số sinh viên:** 2123110071
- **Môn học:** Chuyên Đề ASP.NET Core
- **Giảng viên hướng dẫn:** ThS. Nguyễn Thái Sơn
- **Trường:** Cao đẳng Công Thương Thành phố Hồ Chí Minh
- **Năm học:** 2026
- **Công nghệ sử dụng:** ASP.NET Core MVC, Entity Framework Core, SQL Server,..

---

## 👨‍🎓 Giới Thiệu Đề Tài

Hệ thống Quản lý Nội dung Website (Content Management System - CMS) được xây dựng nhằm hỗ trợ quản trị viên quản lý và tổ chức nội dung trên website một cách hiệu quả.

Đề tài được phát triển bằng ASP.NET Core MVC kết hợp Entity Framework Core và SQL Server, áp dụng mô hình MVC trong xây dựng ứng dụng Web hiện đại.

Hệ thống cho phép quản lý danh mục, bài viết, sản phẩm, khách hàng, đơn hàng và người dùng thông qua giao diện quản trị trực quan.

---

## 🎯 Mục Tiêu Đề Tài

- Tìm hiểu kiến trúc MVC trong ASP.NET Core.
- Xây dựng ứng dụng Web kết nối cơ sở dữ liệu SQL Server.
- Thực hành Entity Framework Core theo phương pháp Code First.
- Thực hiện đầy đủ chức năng CRUD.
- Áp dụng LINQ trong truy vấn dữ liệu.
- Nâng cao kỹ năng phát triển ứng dụng Web bằng C#.

---

## 🛠️ Công Nghệ Sử Dụng

| Công nghệ | Mô tả |
|------------|------------|
| Visual Studio 2022 | Môi trường phát triển |
| ASP.NET Core MVC | Framework xây dựng Web |
| C# | Ngôn ngữ lập trình |
| Entity Framework Core | ORM |
| SQL Server | Hệ quản trị cơ sở dữ liệu |
| SQL Server Management Studio 19 | Quản lý cơ sở dữ liệu |
| LINQ | Truy vấn dữ liệu |
| Razor View Engine | Xây dựng giao diện |
| Bootstrap | Thiết kế giao diện |

---

## 🏗️ Kiến Trúc Hệ Thống

Dự án được xây dựng theo mô hình MVC (Model - View - Controller).

### Model

Quản lý dữ liệu và tương tác với cơ sở dữ liệu thông qua Entity Framework Core.

### View

Hiển thị giao diện người dùng bằng Razor View và Bootstrap.

### Controller

Tiếp nhận yêu cầu từ người dùng, xử lý nghiệp vụ và trả kết quả cho View.

---

## 📂 Cấu Trúc Dự Án

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

## ✨ Chức Năng Hệ Thống

### 📁 Quản Lý Danh Mục

- Hiển thị danh sách danh mục
- Thêm mới danh mục
- Chỉnh sửa danh mục
- Xóa danh mục

### 📰 Quản Lý Bài Viết

- Hiển thị danh sách bài viết
- Thêm bài viết
- Chỉnh sửa bài viết
- Xóa bài viết

### 🛒 Quản Lý Sản Phẩm

- Quản lý sản phẩm
- Quản lý danh mục sản phẩm
- Hiển thị thông tin sản phẩm

### 👤 Quản Lý Người Dùng

- Quản lý tài khoản
- Quản lý thông tin người dùng

### 👥 Quản Lý Khách Hàng

- Thêm khách hàng
- Chỉnh sửa khách hàng
- Xóa khách hàng

### 📦 Quản Lý Đơn Hàng

- Quản lý đơn hàng
- Quản lý chi tiết đơn hàng
- Theo dõi thông tin mua hàng

---

## 🗄️ Cơ Sở Dữ Liệu

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

## 📸 Hình Ảnh Dự Án

### Cấu Trúc Solution

![Solution Structure](images/solution-structure.png)

### Quản Lý Danh Mục

![Category](images/category.png)

### Quản Lý Bài Viết

![Post](images/post.png)

### Quản Lý Sản Phẩm

![Product](images/product.png)

---

## 🚀 Hướng Dẫn Cài Đặt

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

---

## 📚 Kết Quả Đạt Được

- Xây dựng thành công hệ thống CMS bằng ASP.NET Core MVC.
- Kết nối SQL Server bằng Entity Framework Core.
- Hoàn thiện chức năng CRUD cho nhiều đối tượng dữ liệu.
- Áp dụng LINQ trong truy vấn dữ liệu.
- Thực hiện Migration quản lý cơ sở dữ liệu.
- Nắm vững mô hình MVC trong phát triển ứng dụng Web.



---

## 📄 Mục Đích

Dự án được thực hiện nhằm phục vụ học tập, nghiên cứu và thực hành phát triển ứng dụng Web bằng ASP.NET Core MVC.
