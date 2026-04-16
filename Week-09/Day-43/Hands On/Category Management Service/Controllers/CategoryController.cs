using Category_Management_Service.Models;
using Category_Management_Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Category_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var contacts = await _repo.GetAll();
            return Ok(contacts);

        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _repo.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("required Category not found");
            }

            return Ok(category);

        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _repo.CreateCategory(category);

            return Ok(res);

        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _repo.UpdateCategory(id, category);
            if (res == null)
                return NotFound("Required category Not found");
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {


            var flag = await _repo.DeleteCategory(id);
            if (!flag)
                return NotFound("Required category Not found");
            return Ok("category deleted successfully");
        }


    }
}
