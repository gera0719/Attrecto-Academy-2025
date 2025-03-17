using Academy2025.Data;
using Academy2025.DTOs;
using Academy2025.Repositories;

namespace Academy2025.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetByEmailAsync(loginDTO.Email);

            if (user != null && user.Password == loginDTO.Password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
