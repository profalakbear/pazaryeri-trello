using API.Data.Models;
using API.RepositoryContracts;
using API.ServiceContracts;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<User?> Login(string username, string password)
        {
            return _authRepository.Login(username, password);
        }

        public Task<User> Register(User user, string password)
        {
            return _authRepository.Register(user, password);
        }

        public Task<bool> UserExists(string username)
        {
            return _authRepository.UserExists(username);
        }
    }
}
