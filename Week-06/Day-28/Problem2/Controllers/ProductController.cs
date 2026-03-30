using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private List<Products> products = new List<Products>
            {
                new Products { productId = 1, productName = "Laptop", price = 55000, category = "Electronics" },
                new Products { productId = 2, productName = "Mobile", price = 20000, category = "Electronics" },
                new Products { productId = 3, productName = "Chair", price = 1500, category = "Furniture" },
                new Products { productId = 4, productName = "Book", price = 500, category = "Education" },
                new Products { productId = 5, productName = "Headphones", price = 2500, category = "Accessories" }
            };
        public IActionResult Index()
        {
            
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var p = products.FirstOrDefault(e => e.productId == id);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);

        }

    }
}
