using System.ComponentModel.DataAnnotations;

namespace Category_Management_Service.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 100 characters")]
        public string CategoryName { get; set; }

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }
    }
}
