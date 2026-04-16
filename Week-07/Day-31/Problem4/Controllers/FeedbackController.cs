using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if(feedback.Rating >= 4)
            {
                ViewData["Message"] = "Thank You";
            }
            else
            {

                ViewData["Message"] = "We will imrove";
            }
            return View();
        }
    }
}
