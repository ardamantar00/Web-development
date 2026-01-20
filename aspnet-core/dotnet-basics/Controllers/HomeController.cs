using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers;

public class HomeController : Controller
{
    
    public ActionResult Index()
    {
        int number1 = 10,number2=2,sum = 0;
        int div = number1 / number2;
        sum = number1 + number2;
        ViewData["Toplam"] = sum;
        return View(); 
    }
    public ActionResult About() 
    {
       return View(); 
    }
    
    public ActionResult Contact()
    {
        return View(); 
    }
}