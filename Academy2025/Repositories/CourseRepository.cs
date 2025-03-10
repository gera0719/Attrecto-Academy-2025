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
        public async Task CreateAsync(Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }
        public async Task<Course?> UpdateAsync(int id, Course data)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == id);

            if (course != null && course.Id == id)
            {
                course.Title = data.Title;
                course.Description = data.Description;
                course.Url = data.Url;
                course.Author = data.Author;
                course.Users = data.Users;

                await _context.SaveChangesAsync();

                return course;
            }
            return null;
        }
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
