using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
      : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
