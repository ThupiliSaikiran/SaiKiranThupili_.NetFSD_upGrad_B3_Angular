using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }


        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
