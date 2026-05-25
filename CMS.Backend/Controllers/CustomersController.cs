/*
*Sinh vien: Nguyen Thi Thu Thuy
*Ma sv: 2123110071
*Ngay tao: 14-05-2026
*Version: 1.0
*
*/
using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // =========================
    //  DANH SÁCH KHÁCH HÀNG
    // =========================
    public IActionResult Index()
    {
        var data = _context.Customers.ToList();
        return View(data);
    }

    // =========================
    //  XEM CHI TIẾT
    // =========================
    public IActionResult Details(int id)
    {
        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

        if (customer == null)
            return NotFound();

        return View(customer);
    }

    // =========================
    // ❌ XÓA 
    // =========================
    public IActionResult Delete(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer == null)
            return NotFound();

        _context.Customers.Remove(customer);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}