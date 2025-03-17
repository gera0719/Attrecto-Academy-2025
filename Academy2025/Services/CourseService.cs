using Academy2025.Data;
using Academy2025.DTOs;
using Academy2025.Repositories;

namespace Academy2025.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Task CreateAsync(CourseDTO data)
            => _courseRepository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)
            => _courseRepository.DeleteAsync(id);

        public async Task<List<CourseDTO>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(MapToDto).ToList();
        }

        public async Task<CourseDTO?> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            
            return course != null ? MapToDto(course) : null;
        }

        public async Task<CourseDTO?> UpdateAsync(int id, CourseDTO data)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course != null)
            {
                course.Author = data.Author;
                course.Description = data.Description;
                course.Title = data.Title;
                course.Url = data.Url;

                await _courseRepository.UpdateAsync();
            }
            return course != null ? MapToDto(course) : null;
        }
        private static CourseDTO MapToDto(Course course) => new()
        {
            Id = course.Id,
            Title = course.Title,
            Author = course.Author,
            Description = course.Description,
            Url = course.Url
        };
        private static Course MapToModel(CourseDTO courseDTO) => new()
        {
            Id = courseDTO.Id,
            Title = courseDTO.Title,
            Author = courseDTO.Author,
            Description = courseDTO.Description,
            Url = courseDTO.Url
        };
    }
}
