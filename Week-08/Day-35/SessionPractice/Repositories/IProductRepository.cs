using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        void Add(Products product);

        void Update(Products product);

        void Delete(int id);
    }
}
