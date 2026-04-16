using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthenticateRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.AsNoTracking().ToListAsync();
        }

        public  async Task<User> CreateUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return (user);
        }
    }
}
