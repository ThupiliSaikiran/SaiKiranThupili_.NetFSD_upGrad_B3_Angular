using AuthService.Models;
using AuthService.Repository;

namespace AuthService.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _repo;

        public AuthenticateService(IAuthenticateRepository repo)
        {
              _repo = repo;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            var res = await _repo.CreateUserAsync(user);

            return res;
        }
    }
}
