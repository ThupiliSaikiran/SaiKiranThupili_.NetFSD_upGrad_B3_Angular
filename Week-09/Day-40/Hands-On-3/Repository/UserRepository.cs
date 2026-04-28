using Contact_Management_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();


        }

        public async Task<User> GetUser(string email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
                return null;

            return user;
        }
    }
}
