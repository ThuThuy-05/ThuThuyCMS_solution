# 📅 BUỔI 6: WEB API & RESTFUL SERVICE

## 🎯 Mục tiêu bài học

- Hiểu kiến trúc Client - Server trong ứng dụng Web hiện đại.
- Hiểu vai trò của Web API trong việc cung cấp dữ liệu.
- Làm quen với định dạng JSON.
- Xây dựng RESTful API bằng ASP.NET Core.
- Sử dụng Swagger để kiểm thử API.
- Cấu hình CORS để kết nối Backend với ReactJS.

---

## 1. KHÁI NIỆM TRỌNG TÂM: WEB API

Trong mô hình MVC, Backend trả về giao diện HTML.

Trong Web API, Backend chỉ trả về dữ liệu dạng JSON để Frontend (ReactJS, Mobile) tự xử lý giao diện.

### Kiến trúc hệ thống

- Backend (ASP.NET Core): Cung cấp dữ liệu
- Frontend (ReactJS): Hiển thị giao diện
- Giao tiếp qua JSON

---

## 2. JSON LÀ GÌ?

JSON là định dạng dữ liệu dùng để trao đổi giữa Client và Server.

Ví dụ:

```json
{
  "id": 1,
  "title": "ASP.NET Core Web API",
  "author": "Nguyễn Thị Thu Thủy"
}
```

---

## 3. TẠO API CONTROLLER

Tạo controller:

```csharp
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PostsController(ApplicationDbContext context)
    {
        _context = context;
    }
}
```

---

## 4. API LẤY DANH SÁCH BÀI VIẾT

### GET: /api/posts

```csharp
[HttpGet]
public IActionResult GetAll()
{
    var posts = _context.Posts.ToList();
    return Ok(posts);
}
```

---

## 5. API LẤY BÀI VIẾT THEO DANH MỤC

### GET: /api/posts/category/{id}

```csharp
[HttpGet("category/{categoryId}")]
public IActionResult GetByCategory(int categoryId)
{
    var posts = _context.Posts
        .Where(p => p.CategoryId == categoryId)
        .ToList();

    return Ok(posts);
}
```

---

## 6. API CHI TIẾT BÀI VIẾT

### GET: /api/posts/{id}

```csharp
[HttpGet("{id}")]
public IActionResult GetDetail(int id)
{
    var post = _context.Posts.FirstOrDefault(p => p.Id == id);

    if (post == null)
        return NotFound();

    return Ok(post);
}
```

---

## 7. SWAGGER – KIỂM THỬ API

- Công cụ test API trực tiếp trên trình duyệt.
- Xem dữ liệu JSON trả về.
- Kiểm tra các endpoint GET, POST,...

---

## 8. CẤU HÌNH CORS

Cho phép ReactJS truy cập API từ domain khác.

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

app.UseCors("AllowAll");
```

---

## 9. HTTP STATUS CODE

- **200**: Thành công
- **201**: Tạo mới thành công
- **400**: Dữ liệu sai
- **401**: Chưa đăng nhập
- **404**: Không tìm thấy dữ liệu
- **500**: Lỗi hệ thống

---

## 📚 KẾT QUẢ ĐẠT ĐƯỢC

- Hiểu kiến trúc Web API.
- Xây dựng API bằng ASP.NET Core.
- Trả dữ liệu JSON cho Frontend.
- Sử dụng Swagger để kiểm thử API.
- Kết nối ReactJS thông qua CORS.
- Hoàn thiện nền tảng Backend cho hệ thống CMS.
