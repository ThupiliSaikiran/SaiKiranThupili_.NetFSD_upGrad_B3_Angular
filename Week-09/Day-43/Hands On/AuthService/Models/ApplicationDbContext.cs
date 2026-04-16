using Microsoft.EntityFrameworkCore;

namespace AuthService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
