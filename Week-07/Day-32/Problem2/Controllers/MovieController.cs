using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMovies()
        {
            return View(_context.Movies.ToList());
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
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("ShowMovies");
            }
            return View(movie);
        }

        public IActionResult EditMovie(int id)
        {
            Movie movie = _context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            Movie m = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);

            if(m == null)
            {
                return NotFound();
            }
            else
            {
                m.Title = movie.Title;
                m.Genre = movie.Genre;
                m.ReleaseDate = movie.ReleaseDate;  
                m.Price = movie.Price;  
                m.Rating = movie.Rating;

                _context.SaveChanges();

                return RedirectToAction("ShowMovies");

            }

             




        }

        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("ShowMovies");
        }
    }
}
