using AuthService.Models;

namespace AuthService.Service
{
    public interface IAuthenticateService
    {
        Task<List<User>> GetAllUserAsync();

        Task<User> AddUserAsync(User user);
    }
}
