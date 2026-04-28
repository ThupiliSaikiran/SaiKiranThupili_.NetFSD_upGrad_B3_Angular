using Contact_Management_Service.Models;

namespace Contact_Management_Service.Repository
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);

        Task<User> GetUser(string email, string password);
    }

}
