using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IProductService
    {
        IEnumerable<Products> GetProducts();
        Products GetProduct(int id);
        void CreateProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(int id);
    }
}
