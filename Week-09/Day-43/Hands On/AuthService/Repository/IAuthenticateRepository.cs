using AuthService.Models;

namespace AuthService.Repository
{
    public interface IAuthenticateRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> CreateUserAsync(User user);
    }
}
