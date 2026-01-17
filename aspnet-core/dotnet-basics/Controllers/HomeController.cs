using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers;

public class HomeController : Controller
{
    //http://localhost:5298/home/about home --> controller about --> action
    public ActionResult Index()
    {
        return View(); //Views/Home/Index.cshtml
    }
    public ActionResult About() 
    {
       return View(); //Views/Home/About.cshtml
    }
    // http://localhost:5298/home/contact
    public ActionResult Contact()
    {
        return View(); //Views/Home/Contact.cshtml
    }
}