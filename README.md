### 🌿 Buổi 04: Xây Dựng Giao Diện Quản Trị (Admin Panel) Toàn Diện

#### 🎯 Mục tiêu buổi học

Buổi học tập trung xây dựng hệ thống quản trị (Admin Panel) hoàn chỉnh cho dự án CMS bằng ASP.NET Core MVC. Sinh viên thực hành thiết kế giao diện quản trị chuyên nghiệp, xây dựng các chức năng quản lý dữ liệu và thực hiện thao tác CRUD theo mô hình MVC.

---

#### 1️⃣ Xây Dựng Layout Quản Trị

##### Tạo Layout Admin

- Tạo file `_LayoutAdmin.cshtml` trong thư mục `Views/Shared`.
- Xây dựng giao diện quản trị bằng Bootstrap.
- Thiết kế Sidebar điều hướng cho toàn hệ thống.

##### Các chức năng trên Sidebar

- Dashboard
- Danh mục
- Bài viết
- Thành viên
- Danh mục sản phẩm
- Sản phẩm
- Khách hàng
- Đơn hàng
- Chi tiết đơn hàng

##### Công nghệ sử dụng

- Razor Layout
- Bootstrap Grid System
- Bootstrap Icons
- ASP.NET Core Tag Helper

---

#### 2️⃣ Quản Trị Danh Mục (Category Management)

Thực hiện đầy đủ chức năng:

- Hiển thị danh sách danh mục
- Thêm danh mục mới
- Chỉnh sửa danh mục
- Xóa danh mục

Áp dụng Entity Framework Core để thao tác dữ liệu trực tiếp với SQL Server.

---

#### 3️⃣ Quản Trị Bài Viết (Post Management)

##### Hiển thị dữ liệu

Danh sách bài viết được trình bày dưới dạng Card bao gồm:

- Hình ảnh
- Tiêu đề
- Nội dung
- Ngày đăng
- Thông tin liên quan

##### Chức năng thực hiện

- Thêm mới bài viết
- Chỉnh sửa bài viết
- Xóa bài viết
- Upload hình ảnh

##### Upload hình ảnh

Sử dụng:

```csharp
IFormFile
```

Lưu hình ảnh vào:

```text
wwwroot/uploads
```

Tránh trùng tên file bằng:

```csharp
Guid.NewGuid()
```

##### Cập nhật bài viết

Sử dụng:

```csharp
AsNoTracking()
```

Giúp giữ lại hình ảnh cũ khi không upload ảnh mới.

##### Xóa bài viết

Thực hiện theo quy trình:

```text
Find()
→ Remove()
→ SaveChanges()
```

---

#### 4️⃣ Tích Hợp CKEditor 5

##### Mục đích

Hỗ trợ soạn thảo nội dung bài viết trực quan như một hệ quản trị thực tế.

##### Thực hiện

- Tích hợp CKEditor 5 bằng CDN.
- Soạn thảo nội dung HTML.
- Lưu nội dung vào Database.

##### Hiển thị dữ liệu HTML

Sử dụng:

```csharp
@Html.Raw(Model.Content)
```

Giúp hiển thị đúng nội dung HTML đã lưu.

---

#### 5️⃣ Quản Trị Thành Viên (User Management)

##### Chức năng

- Hiển thị danh sách thành viên
- Thêm thành viên
- Chỉnh sửa thông tin
- Xóa thành viên

##### Phân quyền

Hệ thống hỗ trợ:

- Admin
- Editor

##### Kiểm tra dữ liệu

- Kiểm tra Username đã tồn tại.
- Ngăn chặn trùng tài khoản.

##### Cập nhật thông tin

Nếu người dùng không nhập mật khẩu mới:

- Giữ nguyên mật khẩu cũ.
- Chỉ cập nhật các thông tin khác.

---

#### 6️⃣ Quản Trị Danh Mục Sản Phẩm Và Sản Phẩm

##### Danh Mục Sản Phẩm

- Hiển thị danh sách
- Thêm mới
- Chỉnh sửa
- Xóa dữ liệu

##### Sản Phẩm

- CRUD sản phẩm
- Upload hình ảnh sản phẩm
- Liên kết với danh mục sản phẩm

---

#### 7️⃣ Quản Trị Khách Hàng Và Đơn Hàng

##### Quản Lý Khách Hàng

- Hiển thị danh sách khách hàng
- Thêm khách hàng
- Chỉnh sửa thông tin
- Xóa khách hàng

##### Quản Lý Đơn Hàng

- Hiển thị danh sách đơn hàng
- Theo dõi trạng thái đơn hàng
- Xem chi tiết đơn hàng

##### Hiển thị dữ liệu liên kết

Sử dụng Entity Framework Core để hiển thị dữ liệu từ nhiều bảng có quan hệ với nhau.

---

#### 📚 Kiến Thức Đạt Được

##### ASP.NET Core MVC

- Xây dựng giao diện quản trị hoàn chỉnh.
- Thiết kế Layout dùng chung.
- Sử dụng Razor Layout và Partial View.

##### Entity Framework Core

- CRUD dữ liệu.
- Hiển thị dữ liệu liên kết.
- Sử dụng AsNoTracking().

##### Upload File

- Upload hình ảnh bằng IFormFile.
- Quản lý tên file bằng Guid.

##### CKEditor

- Soạn thảo nội dung nâng cao.
- Hiển thị HTML bằng Html.Raw().

##### Quản Trị Hệ Thống

- Phân quyền Admin và Editor.
- Quản lý người dùng.
- Quản lý bài viết và sản phẩm.

---

#### ✅ Kết Quả Đạt Được

Sau buổi học, hệ thống CMS đã hoàn thiện giao diện quản trị chuyên nghiệp với đầy đủ chức năng quản lý dữ liệu.

Hệ thống hỗ trợ:

- CRUD hoàn chỉnh.
- Upload hình ảnh.
- Soạn thảo nội dung bằng CKEditor 5.
- Quản lý thành viên và phân quyền.
- Quản lý sản phẩm, khách hàng và đơn hàng.

Đây là nền tảng quan trọng để triển khai chức năng Authentication và Authorization trong các buổi tiếp theo.
