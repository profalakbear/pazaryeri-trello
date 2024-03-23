using API.Data.Models;

namespace API.RepositoryContracts
{
    public interface IUsersRepository
    {
        Task<User?> GetUserAsync(int userId);
        Task<List<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<User?> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}
