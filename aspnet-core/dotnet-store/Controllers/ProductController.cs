using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public ActionResult Index(int? category)
    {
        IQueryable<Product> query = _context.Products;

        if(category != null)
        {
            query = query.Where(i => i.CategoryId == category);
        }
        var products = query.Select(i=> new ProductGetModel
        {
            Id = i.Id,
            ProductName = i.ProductName,
            Price = i.Price,
            IsActive = i.IsActive,
            IsHome = i.IsHome,
            CategoryName = i.category.CategoryName,
            Image = i.Image
        }).ToList();
        ViewBag.Categories = new SelectList(_context.Categories.ToList(),"Id","CategoryName",category);
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

        if (model.Image == null || model.Image.Length == 0)
        {
            ModelState.AddModelError("Image","Resim Seçmelisiniz");
        }
        if(ModelState.IsValid)
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
            Price = model.Price ?? 0,
            Description = model.Description,
            IsActive = model.IsActive,
            IsHome = model.IsHome,
            CategoryId = (int)model.CategoryId!,
            Image = fileName
            
        };
        _context.Products.Add(entity);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(model);
        
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
        

        if(ModelState.IsValid)
        {
        var entity = _context.Products.FirstOrDefault(i=>i.Id == model.Id);
        ViewBag.Categories = _context.Categories.ToList();

        if(entity != null)
        {
            if(model.Image != null)
            {
                var fileName = Path.GetRandomFileName() + ".jpeg";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img",fileName);
            using (var stream = new FileStream(path,FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);
            }
            entity.Image = fileName;
            }
            entity.ProductName = model.ProductName;
            entity.Description = model.Description;
            entity.Price = model.Price ?? 0;
            entity.IsActive = model.IsActive;
            entity.IsHome = model.IsHome;
            entity.CategoryId = (int)model.CategoryId!;

            _context.SaveChanges();
            TempData["Message"] = $"{entity.ProductName} güncellendi";
            return RedirectToAction("Index");
        }
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(model);
    }
    public ActionResult Delete(int? id)
    {
        if(id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Products.FirstOrDefault(i=>i.Id == id);

        if(entity != null)
        {
            return View(entity);
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteConfirm(int? id)
    {
         if(id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Products.FirstOrDefault(i=>i.Id == id);

        if(entity != null)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
             TempData["Mesaj"] = $"{entity.ProductName} ürünü silindi";
        }
        return RedirectToAction("Index");
    }
}