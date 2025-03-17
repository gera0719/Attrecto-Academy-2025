using Academy2025.Data;
using Academy2025.DTOs;
using Academy2025.Repositories;

namespace Academy2025.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task CreateAsync(UserDTO data)

            => _userRepository.CreateAsync(MapToModel(data));


        public Task<bool> DeleteAsync(int id)

            => _userRepository.DeleteAsync(id);


        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(MapToDto).ToList();
        }

        public async Task<List<UserDTO>> GetAllOverEighteenAsync()
        {
            var users = await _userRepository.GetAllOverEighteenAsync();
            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? MapToDto(user) : null;
        }

        public async Task<UserDTO?> UpdateAsync(int id, UserDTO data)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                user.Name = data.Name;
                await _userRepository.UpdateAsync();
            }
            return user != null ? MapToDto(user) : null;
        }
        private static UserDTO MapToDto(User user)
            => new()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,

            };
        private static User MapToModel(UserDTO userDto) => new()
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
            
        };

    }
}
