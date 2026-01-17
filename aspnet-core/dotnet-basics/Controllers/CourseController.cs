using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers;

    public class CourseController : Controller
    {
       
    //http://localhost:5298/course    
    public ActionResult Index()
    {
        return View();
    }
    //http://localhost:5298/course/list    
    public ActionResult List()
    {
        return View();
    }
     // http://localhost:5298/course/details
    public ActionResult Details()
    {
        return View();
    }
    }
