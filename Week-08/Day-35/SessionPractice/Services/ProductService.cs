using WebApplication2.Models;
using WebApplication2.Repositories;
namespace WebApplication2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Products> GetProducts()
        {
            return _repo.GetAll();
        }

        public Products GetProduct(int id)
        {
            return _repo.GetById(id);
        }

        public void CreateProduct(Products product)
        {
            _repo.Add(product);
        }

        public void UpdateProduct(Products product)
        {
            _repo.Update(product);  
        }

        public void DeleteProduct(int id)
        {
            _repo.Delete(id);
        }
    }
}
