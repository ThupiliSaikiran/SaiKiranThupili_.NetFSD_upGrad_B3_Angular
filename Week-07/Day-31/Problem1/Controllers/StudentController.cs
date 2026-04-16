using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        public static List<Students> students = new List<Students>
        {
            new Students{ StudentName = "Sai" , Age = 23, Course=".NET"},

            new Students{ StudentName = "Kiran" , Age = 24, Course="Python"}

        };


        [Route("List")]
        public IActionResult Index()
        {
            return View(students);
        }



        [Route("add")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Create(Students std)
        {
            if (ModelState.IsValid)
            {
                students.Add(std);
                TempData["StudentName"] = std.StudentName;
                TempData["Age"] =std.Age;
                TempData["Course"] = std.Course;

                // Redirect using route
                return RedirectToAction("Details");
              
            }
            return View(std);
        }


        [HttpGet]
        [Route("details")]
        public IActionResult Details()
        {
            ViewBag.StudentName = TempData["StudentName"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Course = TempData["Course"];
            return View();
        }


    }
}
