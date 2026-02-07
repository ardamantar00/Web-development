using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace dotnet_store.Controllers;

public class ProductController : Controller
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }
    public ActionResult List(string url, string q)
    {
        IQueryable<Product> query = _context.Products;

        if (!string.IsNullOrWhiteSpace(url))
        {
            query = query.Where(i=>i.category!= null && i.category.Url == url);
        }

        if (!string.IsNullOrWhiteSpace(q))
        {
            query = query.Where(i=>i.ProductName.ToLower().Contains(q.ToLower()));
        }
        ViewData["q"] = q;
        return View(query.ToList());
    }
    public ActionResult Index()
    {
        var products = _context.Products.Select(i=> new ProductGetModel
        {
            Id = i.Id,
            ProductName = i.ProductName,
            Price = i.Price,
            IsActive = i.IsActive,
            IsHome = i.IsHome,
            CategoryName = i.category.CategoryName,
            Image = i.Image
        }).ToList();
        return View(products);
    }
    public ActionResult Details(int id)
    {
        // var product = _context.Products.FirstOrDefault(x=>x.Id == id);
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return RedirectToAction("Index", "Home");
        }
        ViewData["SimilarProducts"] = _context.Products
                                        .Where(i => i.IsActive && i.CategoryId == product.CategoryId && i.Id != id)
                                        .Take(4)
                                        .ToList();

        return View(product);
    }

    public ActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductCreateModel model)  
    {
        var fileName = Path.GetRandomFileName() + ".jpeg";
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img",fileName);
        using (var stream = new FileStream(path,FileMode.Create))
        {
            await model.Image!.CopyToAsync(stream);
        }
        var entity = new Product
        {
            ProductName = model.ProductName,
            Price = model.Price,
            Description = model.Description,
            IsActive = model.IsActive,
            IsHome = model.IsHome,
            CategoryId = model.CategoryId,
            Image = fileName
            
        };
        _context.Products.Add(entity);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public ActionResult Edit(int id)
    {
        ViewBag.Categories = _context.Categories.ToList();
        var entity = _context.Products.Select(i=> new ProductEditModel
        {
            Id = i.Id,
            ProductName = i.ProductName,
            Description = i.Description,
            Price = i.Price,
            IsActive = i.IsActive,
            IsHome = i.IsHome,
            CategoryId = i.CategoryId,
            ImageName = i.Image
        }).FirstOrDefault(i=>i.Id == id);
        if(entity == null)
        {
            return RedirectToAction("Index");
        }
        return View(entity);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(int id, ProductEditModel model)
    {
        if(id != model.Id)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Products.FirstOrDefault(i=>i.Id == model.Id);
        ViewBag.Categories = _context.Categories.ToList();

        if(entity != null)
        {
            if(model.ImageFile != null)
            {
                var fileName = Path.GetRandomFileName() + ".jpeg";
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img",fileName);
        using (var stream = new FileStream(path,FileMode.Create))
        {
            await model.ImageFile.CopyToAsync(stream);
        }
        entity.Image = fileName;
            }
            entity.ProductName = model.ProductName;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.IsActive = model.IsActive;
            entity.IsHome = model.IsHome;
            entity.CategoryId = model.CategoryId;

            _context.SaveChanges();
            TempData["Message"] = $"{entity.ProductName} güncellendi";
            return RedirectToAction("Index");
        }
        return View(model);
    }
}