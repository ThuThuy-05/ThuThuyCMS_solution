using CMS.Data;
using Microsoft.AspNetCore.Mvc;

public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var data = _context.Orders.ToList();
        return View(data);
    }
}