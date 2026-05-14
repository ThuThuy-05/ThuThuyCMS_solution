using CMS.Data;
using Microsoft.AspNetCore.Mvc;

public class OrderDetailsController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderDetailsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var data = _context.OrderDetails.ToList();
        return View(data);
    }
}