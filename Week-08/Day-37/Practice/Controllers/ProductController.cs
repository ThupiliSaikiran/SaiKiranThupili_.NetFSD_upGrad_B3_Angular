using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI1.Models;

namespace WebApplicationAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1,Name="Laptop",Price=45000,Category="Electronics" },
            new Product { Id = 2, Name="Mobile",Price=25000,Category="Electronics"  },
            new Product { Id = 3, Name = "TV",Price=3000,Category="Electronics"  }


        };
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProducts(Product product)
        {
            products.Add(product);  
            return Ok(new { product, status = "Product Added Successfully" });
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.Find(p => p.Id == id);
            if(product == null)
            {
                return NotFound("Required request data not found");
            }
            else
            {
                return Ok(new { product, status = "The required product found" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var prod = products.Find(p => p.Id == id);
            if (prod == null)
            {
                return NotFound("Required request data not found");
            }
            else
            {
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.Category = product.Category;

                return Ok(new { UpdatedProd = prod, status = "Product updated successfully!!" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var prod = products.Find(p => p.Id == id);
            if (prod == null)
            {
                return NotFound("Required request data not found");
            }
            else
            {
                products.Remove(prod);
                return Ok(new { Deleted = prod, status = "Product Deleted successfully!!" });
            }
        }


    }
}
