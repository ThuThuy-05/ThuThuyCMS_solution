## 📚 NHẬT KÝ THỰC HIỆN ĐỒ ÁN

### 🌿 Buổi 01: Khởi Tạo Cấu Trúc Đồ Án CMS Full-Stack

#### 🎯 Mục tiêu buổi học

Buổi 01 tập trung xây dựng nền tảng ban đầu cho hệ thống CMS Full-Stack bằng ASP.NET Core MVC và ReactJS. Sinh viên thực hành tạo cấu trúc Solution 3 lớp gồm Data, Backend và Frontend, đồng thời xây dựng các thực thể dữ liệu và tìm hiểu mối quan hệ giữa các bảng trong cơ sở dữ liệu.

---

#### 1️⃣ Khởi tạo Solution

- Tạo Blank Solution với tên **ThuyCMS_Solution**.
- Làm quen với mô hình Solution nhiều Project trong Visual Studio 2022.

---

#### 2️⃣ Xây dựng Project CMS.Data

- Tạo Class Library tên **CMS.Data**.
- Tạo thư mục **Entities**.
- Xây dựng các thực thể dữ liệu:

  - Category
  - Post
  - User
  - CategoryProduct
  - Product
  - Customer
  - Order
  - OrderDetail

---

#### 3️⃣ Thiết kế Database và Quan hệ dữ liệu

- Thiết lập khóa chính (Primary Key).
- Thiết lập khóa ngoại (Foreign Key).
- Xây dựng các mối quan hệ:

  - Category ↔ Post
  - CategoryProduct ↔ Product
  - Customer ↔ Order
  - Order ↔ OrderDetail
  - Product ↔ OrderDetail

- Làm quen với:

  - ICollection
  - ForeignKey
  - Navigation Property

---

#### 4️⃣ Xây dựng Project CMS.Backend

- Tạo Project ASP.NET Core MVC tên **CMS.Backend**.
- Thêm Project Reference tới **CMS.Data**.
- Thiết lập Startup Project.
- Chạy thử ứng dụng ASP.NET Core bằng Visual Studio 2022.

---

#### 5️⃣ Xây dựng Project CMS.Frontend

- Cài đặt Node.js.
- Tạo project ReactJS.
- Thêm project React vào Solution.
- Chạy Frontend bằng:

```bash
npm start
```

hoặc

```bash
npm run dev
```

---

#### 6️⃣ Thực hành Controller và View

- Tạo CategoryController.
- Hiển thị dữ liệu mẫu Category.
- Tạo PostController.
- Hiển thị danh sách bài viết.
- Tạo UserController.
- Hiển thị danh sách thành viên.
- Xây dựng giao diện bằng Razor View và Bootstrap.

---

#### 7️⃣ Kiến thức đạt được

- Cấu trúc Solution 3 lớp.
- ASP.NET Core MVC.
- ReactJS cơ bản.
- Thiết kế Entity.
- Thiết kế cơ sở dữ liệu.
- Controller và Razor View.
- Mock Data.
- Bootstrap.
- Quan hệ dữ liệu trong Entity Framework Core.

---

#### ✅ Kết quả đạt được

Sau buổi học đầu tiên, hệ thống CMS đã hoàn thiện cấu trúc Full-Stack cơ bản gồm:

- CMS.Data
- CMS.Backend
- CMS.Frontend

Sinh viên hiểu được cách tổ chức dự án theo mô hình nhiều lớp, xây dựng Entity, thiết kế cơ sở dữ liệu và hiển thị dữ liệu mẫu trên giao diện ASP.NET Core MVC.
