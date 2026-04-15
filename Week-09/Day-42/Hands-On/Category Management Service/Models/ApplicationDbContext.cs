using Microsoft.EntityFrameworkCore;

namespace Category_Management_Service.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
    }
}
