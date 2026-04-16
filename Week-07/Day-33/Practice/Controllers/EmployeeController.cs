using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Dept).ToList();
            return View(employees);
        }


        public IActionResult Dept()
        {
            var employees = _context.Depts.Include(d => d.Employees).ToList();
            return View(employees);
        }


    }
}
