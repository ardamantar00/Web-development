using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class SliderController: Controller
{
    public ActionResult Index()
    {
        return View();
    }
    public ActionResult Create()
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
}