BUỔI 1: KHỞI TẠO CẤU TRÚC ĐỒ ÁN TỐT NGHIỆP CMS FULL-STACK

Mục tiêu buổi học
Buổi 1 tập trung xây dựng nền tảng ban đầu cho hệ thống CMS Full-Stack bằng ASP.NET Core MVC và ReactJS. Sinh viên thực hành tạo cấu trúc Solution 3 lớp gồm Data, 
Backend và Frontend, đồng thời xây dựng các thực thể dữ liệu và hiểu mối quan hệ giữa các bảng trong Database.
1. Khởi tạo Solution
- Tạo Blank Solution với tên ThuyCMS_Solution
- Làm quen với mô hình Solution nhiều Project trong Visual Studio 2022.
2. Xây dựng Project CMS.Data
- Tạo Class Library tên CMS.Data
- Tạo thư mục Entities
- Xây dựng 8 thực thể chính:
  + Category
  + Post
  + User
  + CategoryProduct
  + Product
  + Customer
  + Order
  + OrderDetail
3. Thiết kế Database và Quan hệ dữ liệu
- Thiết lập khóa chính và khóa ngoại
- Xây dựng quan hệ:
  + Category - Post
  + CategoryProduct - Product
  + Customer - Order
  + Order - OrderDetail
  + Product - OrderDetail
- Làm quen với ICollection và ForeignKey.
4. Xây dựng Project CMS.Backend
- Tạo project ASP.NET Core MVC tên CMS.Backend
- Thêm Project Reference tới CMS.Data
- Thiết lập Startup Project
- Chạy thử ứng dụng ASP.NET Core bằng F5.
5. Xây dựng Project CMS.Frontend
- Cài đặt Node.js
- Tạo project ReactJS bằng create-react-app
- Add project React vào Solution
- Chạy React bằng npm start hoặc npm run dev.
6. Thực hành Controller và View
- Tạo CategoryController và hiển thị dữ liệu mẫu
- Tạo PostController hiển thị danh sách bài viết
- Tạo UserController hiển thị danh sách thành viên
- Xây dựng View bằng Razor và Bootstrap.
7. Kiến thức học được
- Cấu trúc Solution 3 lớp
- ASP.NET Core MVC
- ReactJS cơ bản
- Tạo Entity và thiết kế Database
- Controller và Razor View
- Mock Data
- Bootstrap giao diện
- Quan hệ dữ liệu trong Entity Framework Core.
Kết quả sau buổi học
Sau buổi 1, hệ thống CMS đã hoàn thiện cấu trúc Full-Stack cơ bản gồm Data, Backend và Frontend. Sinh viên hiểu cách tổ chức dự án chuyên nghiệp, xây dựng Entity, thiết kế Database và hiển thị dữ liệu mẫu trên giao diện MVC.
