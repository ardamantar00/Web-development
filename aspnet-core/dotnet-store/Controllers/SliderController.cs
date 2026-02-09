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
        var sliders = _context.Sliders.ToList();
        return View(sliders);
    }
    public ActionResult Create()
    {

        return View();
    }
    [HttpPost]  
    public ActionResult Create(SliderCreateModel model)
    {
        return View();
    }
    public ActionResult Edit()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Edit(int id)
    {
        return View();
    }

    [HttpPost]
    public ActionResult Delete(int? id)
    {
        return View();
    }

    [HttpPost]
     public ActionResult DeleteConfirm(int? id)
    {
        return View();
    }
}