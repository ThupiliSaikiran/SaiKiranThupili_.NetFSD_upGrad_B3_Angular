using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMovies()
        {
            return View(_service.GetAllMovies());
        }

        public IActionResult AddMovie()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.Add(movie);

                return RedirectToAction("ShowMovies");
            }
            return View(movie);
        }

        public IActionResult EditMovie(int Id)
        {
            Movie movie = _service.GetMovieById(Id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(movie);
                return RedirectToAction("ShowMovies");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Product details.";
                return View();
            }






        }

        public IActionResult DeleteMovie(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            

            _service.Delete(movie);
            return RedirectToAction("ShowMovies");
        }
    }
}
