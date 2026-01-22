using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class ProductController : Controller
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }
    public ActionResult List()
    {
        var products = _context.Products.Where(i=> i.IsActive).ToList();
        return View(products);
    }
     public ActionResult Index()
    {
       
        return View();
    }
    public ActionResult Details(int id)
    {
        var product = _context.Products.FirstOrDefault(x=>x.Id == id);
        // var product = _context.Products.Find(id);
        return View(product);
    }
}