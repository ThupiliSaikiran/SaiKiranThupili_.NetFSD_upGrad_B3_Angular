using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpPost]
        [Route("")]
        public IActionResult Index(int Number1, int Number2)
        {
            int result = Number1 + Number2;

            ViewBag.Result= result;
            return View();
        }
    }
}
