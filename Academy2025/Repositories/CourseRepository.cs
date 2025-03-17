using Academy2025.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy2025.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context )
        {
            _context = context;
        }
        public Task<List<Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public Task<Course?> GetByIdAsync(int id)
        {
            
            return _context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        }
        public Task<List<Course?>> GetByAuthorAsync(string author)
        {
            return _context.Courses.Where(course => course.Author == author).ToListAsync();
        }
        public async Task CreateAsync(Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }
        public Task<int> UpdateAsync()
            => _context.SaveChangesAsync();
        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == id);
            if (course != null && course.Id == id)
            {
                _context.Courses.Remove(course);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
