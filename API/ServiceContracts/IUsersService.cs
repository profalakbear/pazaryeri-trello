using API.Data.Models;
using API.DTOs;

namespace API.ServiceContracts
{
    public interface IUsersService 
    {
        Task<UserDTO?> GetUserAsync(int userId);
        Task<UserDTO?> UpdateUserAsync(UserDTO userDto);
    }
}
