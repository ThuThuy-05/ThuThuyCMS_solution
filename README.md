BUỔI 3: TRUY VẤN LINQ & THAO TÁC DỮ LIỆU CHUYÊN SÂU

1.	Mục tiêu chính của buổi học

Buổi này tập trung vào 2 phần quan trọng:
•	LINQ trong Entity Framework Core
•	Lọc dữ liệu bằng Where()
•	Sắp xếp dữ liệu bằng OrderByDescending()
•	Lấy 1 phần tử bằng FirstOrDefault()
•	Join bảng bằng Include()
•	Lấy số lượng giới hạn bằng Take()
•	CRUD dữ liệu
Thực hiện:
•	Thêm dữ liệu (Create)
•	Xóa dữ liệu (Delete)
•	Sửa dữ liệu (Update)

2.	LINQ – Truy vấn dữ liệu

2.1. Lọc dữ liệu bằng Where()
Ví dụ:
var posts = _context.Posts
    .Where(p => p.CategoryId == id)
    .ToList();
Ý nghĩa:
Chỉ lấy bài viết thuộc danh mục có CategoryId = id.

2.2. Sắp xếp dữ liệu bằng OrderByDescending()
.OrderByDescending(p => p.CreatedDate)
Ý nghĩa:
Bài viết mới nhất hiển thị đầu tiên.

2.3. Join bảng bằng Include()
.Include(p => p.Category)
Ý nghĩa:
Lấy thêm dữ liệu từ bảng Category.
Giúp dùng được:
@item.Category.Name
Nếu không có Include():
Category.Name sẽ bị null.

2.4. Lấy 1 dòng dữ liệu bằng FirstOrDefault()
.FirstOrDefault(p => p.Id == id)
Ý nghĩa:
Lấy bài viết đầu tiên đúng điều kiện.
Nếu không có → trả về null.

2.5. Lấy giới hạn dữ liệu bằng Take()
.Ta
Ý nghĩa:
Chỉ lấy 3 bài viết đầu tiên.

3.	CRUD – Thao tác dữ liệu

3.1. CREATE – Thêm dữ liệu
Hàm GET
[HttpGet]
public IActionResult Create()
{
    return View();
}
Ý nghĩa:
Mở form nhập liệu.
Hàm POST
[HttpPost]
public IActionResult Create(Category model)
{
    _context.Categories.Add(model);
    _context.SaveChanges();
    return RedirectToAction("Index");
}
Quy trình lưu dữ liệu gồm 2 bước
Bước 1
_context.Categories.Add(model);
Thêm dữ liệu vào bộ nhớ tạm.
Bước 2
_context.SaveChanges();
Ghi thật xuống SQL Server.
⚠ Nếu thiếu SaveChanges():
Dữ liệu sẽ KHÔNG được lưu.

3.2. DELETE – Xóa dữ liệu
public IActionResult Delete(int id)
{
    var category = _context.Categories.Find(id);
    if (category != null)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }
    return RedirectToAction("Index");
}
Quy trình xóa gồm 3 bước
Tìm dữ liệu bằng Find(id)
Xóa tạm bằng Remove()
Xóa thật bằng SaveChanges()

3.3. UPDATE – Sửa dữ liệu
GET: Hiển thị dữ liệu cũ
[HttpGet]
public IActionResult Edit(int id)
{
    var category = _context.Categories.Find(id);
    return View(category);
}
POST: Lưu dữ liệu mới
[HttpPost]
public IActionResult Edit(Category model)
{
    _context.Categories.Update(model);
    _context.SaveChanges();
    return RedirectToAction("Index");
}
Quan trọng
<input type="hidden" asp-for="Id" />
 Không được quên:
Nếu thiếu → hệ thống không biết sửa dòng nào.

4. Kiến thức quan trọng cần nhớ
Công thức LINQ tổng quát
var data = _context.TableName
            .Where(...)
            .OrderBy(...)
            .Include(...)
            .ToList();

5. Kiến thức trọng tâm của buổi

•	LINQ
•	Where() → Lọc
•	OrderByDescending() → Sắp xếp giảm dần
•	Include() → Join bảng
•	FirstOrDefault() → Lấy 1 dòng
•	Take() → Giới hạn số dòng
•	CRUD
•	Add() → Thêm
•	Update() → Sửa
•	Remove() → Xóa
•	SaveChanges() → Lưu thật xuống Database

6. Kết quả đạt được sau buổi học

Sau buổi 3 mình có thể:
•	Truy vấn dữ liệu bằng LINQ.
•	Join nhiều bảng bằng Include().
•	Hiển thị dữ liệu từ SQL Server lên View.
•	Thực hiện CRUD hoàn chỉnh với ASP.NET Core MVC + EF Core.
•	Hiểu luồng GET và POST trong Controller.
