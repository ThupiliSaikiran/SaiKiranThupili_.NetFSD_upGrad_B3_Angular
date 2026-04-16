using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service=service;
        }
        public IActionResult Index()
        {
            return View(_service.GetProducts());
        }

        public IActionResult GetById(int id)
        {
            var product = _service.GetProduct(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Products product)
        {
            if (ModelState.IsValid)
            {
                _service.CreateProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Product details.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var prodObj = _service.GetProduct(id);
            return View(prodObj);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Products product)
        {
           if(ModelState.IsValid)
            {
                _service.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Product details.";
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prodObj = _service.GetProduct(id);
            return View(prodObj);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _service.GetProduct(id);

            if (prodObj != null)
            {
                _service.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested product does not exists";
                return View();
            }
        }

    }
}
