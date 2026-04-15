using Category_Management_Service.Models;

namespace Category_Management_Service.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategory(Category category);

        Task<Category> UpdateCategory(int id, Category category);

        Task<bool> DeleteCategory(int id);
    }
}
