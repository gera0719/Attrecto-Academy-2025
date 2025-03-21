﻿using Academy2025.Data;

namespace Academy2025.Repositories
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course data);
        Task<bool> DeleteAsync(int id);
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<List<Course?>> GetByAuthorAsync(string author);
        Task<int> UpdateAsync();
    }
}
