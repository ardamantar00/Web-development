using dotnet_basics.Models;
using Microsoft.AspNetCore.Mvc;
namespace dotnet_basics.Controllers;

    public class CourseController : Controller
    {
       List<Course> kurslar = new List<Course>
        {
          new Course{Id = 1,Title = "Web kursu", Description = "Web kursu açıklaması",Image = "1.png",IsActive = true,IsHome = true},
          new Course{Id = 2,Title = "Veri bilimi kursu",Description = "Veri bilimi kursu açıklaması",Image = "2.png",IsActive = true,IsHome = true},
          new Course{Id = 3,Title = "Sql kursu",Description = "Sql kursu açıklaması",Image = "sql.png",IsActive = true,IsHome = true},
          new Course{Id = 4,Title = "Sql kursu",Description = "Sql kursu açıklaması",Image = "sql.png",IsActive = true,IsHome = true},
          new Course{Id = 5,Title = "Sql kursu",Description = "Sql kursu açıklaması",Image = "sql.png",IsActive = true,IsHome = true},
          new Course{Id = 6,Title = "Sql kursu",Description = "Sql kursu açıklaması",Image = "sql.png",IsActive = true,IsHome = false},
          new Course{Id = 7,Title = "Sql kursu",Description = "Sql kursu açıklaması",Image = "sql.png",IsActive = true,IsHome = false},
        };

    public ActionResult Index()
    {
     
        return View(kurslar);
    }
       
    public ActionResult List()
    {
        return View(kurslar);
    }
    
    public ActionResult Details(int id)
    {
        Course? kurs = kurslar.Where(i=>i.Id == id).FirstOrDefault();
        
        return View(kurs);
    }
    }
