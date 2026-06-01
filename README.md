### 🌿 Buổi 05: Bảo Mật & Phân Quyền (Security & Identity)

#### 🎯 Mục tiêu buổi học

Buổi học tập trung xây dựng hệ thống bảo mật cho CMS bằng ASP.NET Core MVC, bao gồm:

- Authentication (Xác thực người dùng)
- Authorization (Phân quyền người dùng)
- Cookie Authentication
- Role-Based Authorization
- Quản lý đăng nhập và đăng xuất
- Bảo vệ các trang quản trị

---

#### 1️⃣ Tìm Hiểu Luồng Đăng Nhập (Login Flow)

Quy trình hoạt động của hệ thống:

1. Người dùng nhập Username và Password.
2. Hệ thống kiểm tra thông tin trong Database.
3. Nếu hợp lệ, hệ thống tạo Cookie xác thực.
4. Người dùng được cấp quyền truy cập khu vực quản trị.

---

#### 2️⃣ Cấu Hình Cookie Authentication

Trong file `Program.cs`:

- Đăng ký dịch vụ Authentication.
- Sử dụng Cookie Authentication.
- Thiết lập trang Login.
- Thiết lập trang Access Denied.

Đồng thời kích hoạt Middleware:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

---

#### 3️⃣ Xây Dựng Chức Năng Đăng Nhập

##### AccountController

Tạo `AccountController` để quản lý:

- Login
- Logout
- Access Denied

##### Giao Diện Login

Xây dựng trang:

```text
/Account/Login
```

Sử dụng:

- Razor View
- Bootstrap 5
- Form đăng nhập

Người dùng nhập:

- Username
- Password

---

#### 4️⃣ Xử Lý Xác Thực Người Dùng

Hệ thống:

- Kiểm tra tài khoản trong bảng Users.
- Tạo Claims chứa thông tin người dùng.
- Tạo Identity và Principal.
- Lưu Cookie Authentication vào trình duyệt.

Thông tin được lưu:

- Username
- FullName
- Role (Admin hoặc Editor)

---

#### 5️⃣ Đăng Xuất Hệ Thống

Thực hiện:

- Xóa Cookie Authentication.
- Chuyển về trang Login.

Giúp kết thúc phiên làm việc an toàn.

---

#### 6️⃣ Các Khái Niệm Quan Trọng

##### Claim

Là thông tin của người dùng:

- Tên đăng nhập
- Họ tên
- Vai trò

##### Identity

Là tập hợp các Claim.

##### Principal

Đại diện cho người dùng đang đăng nhập trong hệ thống.

---

#### 7️⃣ Bảo Vệ Khu Vực Quản Trị

Sử dụng thuộc tính:

```csharp
[Authorize]
```

Áp dụng cho:

- CategoryController
- PostController
- UserController
- Các Controller quản trị khác

Kết quả:

- Người chưa đăng nhập không thể truy cập.
- Hệ thống tự động chuyển về trang Login.

---

#### 8️⃣ Phân Quyền Theo Vai Trò (Role-Based Authorization)

Sử dụng:

```csharp
[Authorize(Roles = "Admin")]
```

Áp dụng cho:

- UserController

Quyền truy cập:

| Vai trò | Quyền |
|----------|----------|
| Admin | Truy cập toàn bộ hệ thống |
| Editor | Chỉ quản lý nội dung được cấp phép |

---

#### 9️⃣ Hiển Thị Thông Tin Người Đăng Nhập

Trên giao diện quản trị:

- Hiển thị FullName.
- Hiển thị Role.
- Hiển thị nút Đăng xuất.

Ví dụ:

```text
Chào, Nguyễn Thị Thu Thủy (Admin)
```

---

#### 🔟 Xử Lý Access Denied

Tạo trang:

```text
/Account/AccessDenied
```

Hiển thị thông báo:

```text
403 - KHÔNG CÓ QUYỀN TRUY CẬP
```

Khi người dùng cố truy cập vào khu vực không được phép.

---

#### 📚 Kiến Thức Đạt Được

- Authentication bằng Cookie.
- Authorization bằng thuộc tính Authorize.
- Role-Based Authorization.
- Claims, Identity và Principal.
- Quản lý Login và Logout.
- Bảo vệ khu vực Admin.
- Xử lý Access Denied.
- Hiển thị thông tin người dùng trên Layout.

---

#### ✅ Kết Quả Đạt Được

Sau buổi học, hệ thống CMS đã được tích hợp cơ chế bảo mật hoàn chỉnh:

- Đăng nhập và đăng xuất bằng Cookie Authentication.
- Quản lý phiên đăng nhập.
- Bảo vệ các khu vực quản trị.
- Phân quyền Admin và Editor.
- Hiển thị thông tin người dùng đang đăng nhập.
- Ngăn chặn truy cập trái phép vào hệ thống.

Đây là nền tảng quan trọng để triển khai các chức năng bảo mật nâng cao và phát triển hệ thống quản trị chuyên nghiệp trong các giai đoạn tiếp theo.
