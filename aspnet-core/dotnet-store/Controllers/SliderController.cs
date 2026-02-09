using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class SliderController: Controller
{
    private readonly DataContext _context;
    public SliderController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        var sliders = _context.Sliders.Select(i=> new SliderGetModel
        {
            Id = i.Id,
            Title = i.Title,
            IsActive = i.IsActive,
            Index = i.Index,
            Image = i.Image
        }).ToList();
        return View(sliders);
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]  
    public async Task<ActionResult> Create(SliderCreateModel model)
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
        var entity = new Slider
        {
            Title = model.Title,
            Description = model.Description,
            IsActive = model.IsActive,
            Index = model.Index,
            Image = fileName
            
        };
        _context.Sliders.Add(entity);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(model);
        
    }
    public ActionResult Edit(int id)
    {
        var entity = _context.Sliders.Select(i=> new SliderEditModel
        {
            Id = i.Id,
            Title = i.Title,
            IsActive = i.IsActive,
            Index = i.Index,
            ImageName = i.Image
        }).FirstOrDefault(i=>i.Id == id);
        if(entity == null)
        {
            return RedirectToAction("Index");
        }
        return View(entity);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(int id, SliderEditModel model)
    {

        if(id != model.Id)
        {
            return RedirectToAction("Index");
        }
        

        // if(ModelState.IsValid)
        
        var entity = _context.Sliders.FirstOrDefault(i=>i.Id == model.Id);

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
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.IsActive = model.IsActive;
            entity.Index = model.Index;
            _context.SaveChanges();
            TempData["Message"] = $"{entity.Title} isimli slider güncellendi";
            return RedirectToAction("Index");
        }
        return View(model);
    }


        public ActionResult Delete(int? id)
    {
        if(id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Sliders.FirstOrDefault(i=>i.Id == id);

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
        var entity = _context.Sliders.FirstOrDefault(i=>i.Id == id);

        if(entity != null)
        {
            _context.Sliders.Remove(entity);
            _context.SaveChanges();
            TempData["Mesaj"] = $"{entity.Title} Slideri silindi";
        }
        return RedirectToAction("Index");
    }

}
