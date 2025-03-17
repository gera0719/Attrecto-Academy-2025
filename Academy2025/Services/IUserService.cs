using Academy2025.Data;
using Academy2025.DTOs;

namespace Academy2025.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDTO data);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
        Task<UserDTO?> UpdateAsync(int id, UserDTO data);
        Task<List<UserDTO>> GetAllOverEighteenAsync();
    }
}
