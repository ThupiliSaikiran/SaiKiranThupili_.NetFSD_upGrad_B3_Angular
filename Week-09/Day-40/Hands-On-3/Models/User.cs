using System.ComponentModel.DataAnnotations;

namespace Contact_Management_Service.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [StringLength(50)]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

 
        public string? Role { get; set; }
    }
}
