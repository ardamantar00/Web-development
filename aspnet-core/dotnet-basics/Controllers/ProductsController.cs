using Microsoft.AspNetCore.Mvc;
namespace dotnet_basics.Controllers;
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
    }
