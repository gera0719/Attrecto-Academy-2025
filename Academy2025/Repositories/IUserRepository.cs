using Academy2025.Data;

namespace Academy2025.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User data);
        Task<bool> DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<int> UpdateAsync();
        Task<List<User>> GetAllOverEighteenAsync();
    }
}