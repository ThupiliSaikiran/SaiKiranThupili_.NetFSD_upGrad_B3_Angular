using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>()
        {
            new Product { ProductId = 1, ProductName = "Laptop",      Price = 55000, Category = "Electronics" },
            new Product { ProductId = 2, ProductName = "Mobile",      Price = 20000, Category = "Electronics" },
            new Product { ProductId = 3, ProductName = "Chair",       Price = 3000,  Category = "Furniture"   },
            new Product { ProductId = 4, ProductName = "Notebook",    Price = 50,    Category = "Stationery"  },
            new Product { ProductId = 5, ProductName = "Headphones",  Price = 1500,  Category = "Electronics" }
        };
        public IActionResult Index()
        {

            return View(products);
        }
        public IActionResult Details(int id)
        {
            Product prodObj = products.FirstOrDefault(prod => prod.ProductId == id);
            return View(prodObj);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product Obj)
        {
            products.Add(Obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product Obj = products.FirstOrDefault(prod =>prod.ProductId == id);
            return View(Obj);
        }

        [HttpPost]
        public IActionResult Edit(Product Obj)
        {
            Product prod = products.FirstOrDefault(prod => prod.ProductId == Obj.ProductId);

            prod.ProductName= Obj.ProductName;
            prod.Price = Obj.Price;
            prod.Category = Obj.Category;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product Obj = products.FirstOrDefault(prod => prod.ProductId == id);
            return View(Obj);
        }


    }
}
