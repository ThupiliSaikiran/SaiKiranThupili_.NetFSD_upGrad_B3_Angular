using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI1.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}
