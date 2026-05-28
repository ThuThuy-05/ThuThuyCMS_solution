BUỔI 4: XÂY DỰNG GIAO DIỆN QUẢN TRỊ (ADMIN PANEL) TOÀN DIỆN

Mục tiêu buổi học
Buổi 4 tập trung xây dựng hệ thống quản trị (Admin Panel) hoàn chỉnh cho dự án CMS bằng ASP.NET Core MVC. Sinh viên thực hành thiết kế giao diện quản trị chuyên nghiệp, xây dựng chức năng quản lý dữ liệu và thao tác CRUD theo mô hình MVC.
1. Xây dựng Layout quản trị (_LayoutAdmin.cshtml)
- Tạo file _LayoutAdmin.cshtml trong Views/Shared
- Thiết kế giao diện quản trị bằng Bootstrap
- Xây dựng Sidebar điều hướng gồm: Dashboard, Danh mục, Bài viết, Thành viên, Danh mục sản phẩm, Sản phẩm, Khách hàng, Đơn hàng, Chi tiết đơn hàng
- Sử dụng Razor Layout, Bootstrap Grid System, Bootstrap Icons và Tag Helper.
2. Quản trị Danh mục (Category Management)
- Hiển thị danh sách danh mục
- Thêm, sửa, xóa danh mục
- Thực hành CRUD với Entity Framework Core.
3. Quản trị Bài viết (Post Management)
- Hiển thị bài viết dạng Card gồm ảnh, tiêu đề, nội dung, ngày đăng,...
- Thêm mới bài viết bằng Form MVC
- Upload ảnh bằng IFormFile và lưu vào wwwroot/uploads
- Dùng Guid.NewGuid() tránh trùng tên file
- Sửa bài viết và giữ lại ảnh cũ bằng AsNoTracking()
- Xóa bài viết bằng quy trình Find → Remove → SaveChanges.
4. Tích hợp CKEditor 5
- Tích hợp CKEditor bằng CDN
- Hỗ trợ soạn thảo nội dung nâng cao
- Hiển thị nội dung HTML bằng Html.Raw().
5. Quản trị Thành viên (User Management)
- Hiển thị danh sách thành viên
- Thêm, sửa, xóa User
- Phân quyền Admin và Editor
- Kiểm tra Username tồn tại
- Giữ mật khẩu cũ nếu không nhập mật khẩu mới.
6. Quản trị Danh mục sản phẩm và Sản phẩm
- CRUD danh mục sản phẩm
- CRUD sản phẩm
- Upload ảnh sản phẩm và liên kết với danh mục.
7. Quản trị Khách hàng và Đơn hàng
- Quản lý khách hàng
- Quản lý đơn hàng và chi tiết đơn hàng
- Hiển thị dữ liệu liên kết bằng Entity Framework Core.
Kết quả sau buổi học
Sau buổi 4, hệ thống CMS đã có giao diện quản trị hoàn chỉnh, hỗ trợ CRUD dữ liệu, upload hình ảnh, soạn thảo nội dung bằng CKEditor và phân quyền Admin/Editor, sẵn sàng cho phần Authentication và Authorization ở buổi tiếp theo.
