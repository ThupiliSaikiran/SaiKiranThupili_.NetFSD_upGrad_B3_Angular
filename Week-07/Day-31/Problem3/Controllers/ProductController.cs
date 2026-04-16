using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Price = 75000, Quantity = 10 },
            new Product { ProductId = 2, ProductName = "Mobile", Price = 25000, Quantity = 25 },
            new Product { ProductId = 3, ProductName = "Headphones", Price = 2000, Quantity = 50 },
            new Product { ProductId = 4, ProductName = "Keyboard", Price = 1500, Quantity = 30 },
            new Product { ProductId = 5, ProductName = "Mouse", Price = 800, Quantity = 40 }
        };
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Message = "Welcome to Product";
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product prod)
        {
            if (ModelState.IsValid)
            {
                prod.ProductId = products.Max(p => p.ProductId) + 1;

                products.Add(prod);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Message = "Something is Wrong";
                return View();
            }
            
           
        }
    }
}
