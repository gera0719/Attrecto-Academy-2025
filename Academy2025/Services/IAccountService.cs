using Academy2025.Data;
using Academy2025.DTOs;

namespace Academy2025.Services
{
    public interface IAccountService
    {
        Task<User?> LoginAsync(LoginDTO loginDTO);
    }
}
