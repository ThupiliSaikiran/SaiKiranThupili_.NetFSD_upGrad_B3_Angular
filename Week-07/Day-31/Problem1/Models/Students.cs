using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Students
    {
        [Required]
        public string StudentName {  get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Course {  get; set; }

    }
}
