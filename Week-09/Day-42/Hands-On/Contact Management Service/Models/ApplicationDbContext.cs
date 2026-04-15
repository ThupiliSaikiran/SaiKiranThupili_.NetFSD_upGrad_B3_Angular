using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
