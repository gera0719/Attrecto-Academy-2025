﻿using Academy2025.Data;

namespace Academy2025.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User data);
        Task<bool> DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> UpdateAsync(int id, User data);
        Task<List<User>> GetAllOverEighteenAsync();
    }
}