using CMS.Data;
using Microsoft.AspNetCore.Mvc;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var data = _context.Customers.ToList();
        return View(data);
    }
}