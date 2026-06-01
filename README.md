### 🌿 Buổi 03: Truy Vấn LINQ & Thao Tác Dữ Liệu Chuyên Sâu

#### 🎯 Mục tiêu buổi học

Buổi học tập trung tìm hiểu cách truy vấn dữ liệu bằng LINQ trong Entity Framework Core và thực hiện các thao tác CRUD (Create, Read, Update, Delete) trên cơ sở dữ liệu SQL Server thông qua ASP.NET Core MVC.

---

#### 1️⃣ Nội dung trọng tâm

##### LINQ trong Entity Framework Core

- Lọc dữ liệu bằng `Where()`
- Sắp xếp dữ liệu bằng `OrderByDescending()`
- Lấy một bản ghi bằng `FirstOrDefault()`
- Join bảng bằng `Include()`
- Giới hạn số lượng dữ liệu bằng `Take()`

##### CRUD dữ liệu

- Create (Thêm dữ liệu)
- Read (Đọc dữ liệu)
- Update (Cập nhật dữ liệu)
- Delete (Xóa dữ liệu)

---

#### 2️⃣ Truy Vấn Dữ Liệu Bằng LINQ

##### 2.1 Lọc dữ liệu với Where()

Ví dụ:

```csharp
var posts = _context.Posts
    .Where(p => p.CategoryId == id)
    .ToList();
```

Ý nghĩa:

- Chỉ lấy các bài viết thuộc danh mục có `CategoryId = id`.

---

##### 2.2 Sắp xếp dữ liệu với OrderByDescending()

Ví dụ:

```csharp
.OrderByDescending(p => p.CreatedDate)
```

Ý nghĩa:

- Hiển thị bài viết mới nhất trước.

---

##### 2.3 Join bảng với Include()

Ví dụ:

```csharp
.Include(p => p.Category)
```

Ý nghĩa:

- Lấy thêm dữ liệu từ bảng Category.
- Cho phép truy cập:

```csharp
@item.Category.Name
```

Nếu không sử dụng `Include()` thì dữ liệu Category có thể không được tải và giá trị sẽ bị null.

---

##### 2.4 Lấy một bản ghi với FirstOrDefault()

Ví dụ:

```csharp
.FirstOrDefault(p => p.Id == id)
```

Ý nghĩa:

- Lấy bản ghi đầu tiên thỏa điều kiện.
- Nếu không tìm thấy dữ liệu sẽ trả về `null`.

---

##### 2.5 Giới hạn số lượng dữ liệu với Take()

Ví dụ:

```csharp
.Take(3)
```

Ý nghĩa:

- Chỉ lấy 3 bản ghi đầu tiên.

---

#### 3️⃣ CRUD Dữ Liệu

### CREATE – Thêm dữ liệu

##### GET: Hiển thị form nhập liệu

```csharp
[HttpGet]
public IActionResult Create()
{
    return View();
}
```

##### POST: Lưu dữ liệu

```csharp
[HttpPost]
public IActionResult Create(Category model)
{
    _context.Categories.Add(model);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
```

Quy trình lưu dữ liệu:

**Bước 1**

```csharp
_context.Categories.Add(model);
```

Thêm dữ liệu vào bộ nhớ tạm của Entity Framework Core.

**Bước 2**

```csharp
_context.SaveChanges();
```

Ghi dữ liệu xuống SQL Server.

⚠️ Nếu thiếu `SaveChanges()` dữ liệu sẽ không được lưu.

---

### DELETE – Xóa dữ liệu

```csharp
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
```

Quy trình xóa:

1. Tìm dữ liệu bằng `Find(id)`
2. Đánh dấu xóa bằng `Remove()`
3. Lưu thay đổi bằng `SaveChanges()`

---

### UPDATE – Cập nhật dữ liệu

##### GET: Hiển thị dữ liệu cần sửa

```csharp
[HttpGet]
public IActionResult Edit(int id)
{
    var category = _context.Categories.Find(id);

    return View(category);
}
```

##### POST: Cập nhật dữ liệu

```csharp
[HttpPost]
public IActionResult Edit(Category model)
{
    _context.Categories.Update(model);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
```

Trong View cần có:

```html
<input type="hidden" asp-for="Id" />
```

⚠️ Không được bỏ qua trường Id, nếu thiếu hệ thống sẽ không xác định được bản ghi cần cập nhật.

---

#### 4️⃣ Công Thức LINQ Tổng Quát

```csharp
var data = _context.TableName
                   .Where(...)
                   .OrderBy(...)
                   .Include(...)
                   .ToList();
```

Công thức này thường được sử dụng trong hầu hết các chức năng truy vấn dữ liệu của hệ thống.

---

#### 📚 Kiến Thức Đạt Được

##### LINQ

- `Where()` → Lọc dữ liệu
- `OrderByDescending()` → Sắp xếp giảm dần
- `Include()` → Join bảng
- `FirstOrDefault()` → Lấy một bản ghi
- `Take()` → Giới hạn số lượng dữ liệu

##### CRUD

- `Add()` → Thêm dữ liệu
- `Update()` → Cập nhật dữ liệu
- `Remove()` → Xóa dữ liệu
- `SaveChanges()` → Lưu thay đổi xuống Database

##### ASP.NET Core MVC

- Hiểu luồng xử lý GET và POST.
- Kết hợp Controller với Entity Framework Core.
- Hiển thị dữ liệu từ SQL Server lên View.

---

#### ✅ Kết Quả Đạt Được

Sau buổi học, hệ thống CMS đã:

- Truy vấn dữ liệu bằng LINQ.
- Kết hợp nhiều bảng dữ liệu thông qua Include().
- Hiển thị dữ liệu thực từ SQL Server lên giao diện MVC.
- Hoàn thiện chức năng CRUD bằng ASP.NET Core MVC và Entity Framework Core.
- Hiểu rõ quy trình xử lý GET và POST trong Controller.
