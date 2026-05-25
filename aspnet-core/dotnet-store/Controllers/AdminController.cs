using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly DataContext _context;

    public AdminController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        ViewBag.TotalSales    = _context.Orders.Sum(o => (double?)o.TotalPrice) ?? 0;
        ViewBag.TotalOrders   = _context.Orders.Count();
        ViewBag.TotalProducts = _context.Products.Count();
        ViewBag.RecentOrders  = _context.Orders
            .OrderByDescending(o => o.OrderTime)
            .Take(10)
            .ToList();

        return View();
    }
}
