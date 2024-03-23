using API.Data.Models;
using API.DTOs;
using API.RepositoryContracts;
using API.ServiceContracts;
using AutoMapper;

namespace API.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetUserAsync(int userId)
        {
            var user = await _usersRepository.GetUserAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> UpdateUserAsync(UserDTO userDto)
        {
            userDto.UpdatedAt = DateTime.Now;
            var user = _mapper.Map<User>(userDto);
            var updatedUser = await _usersRepository.UpdateUserAsync(user);
            return _mapper.Map<UserDTO>(updatedUser);
        }

    }
}
