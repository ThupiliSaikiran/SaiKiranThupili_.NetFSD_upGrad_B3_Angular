using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Models
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
       : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
