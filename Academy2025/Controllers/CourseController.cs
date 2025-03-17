using Academy2025.DTOs;
using Microsoft.AspNetCore.Mvc;
using Academy2025.Services;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //public static List<Course>? Courses = new List<Course>();
        private readonly ICourseService _courseService;
        // GET: api/<CourseController>
        public CourseController( ICourseService courseService )
        {
            _courseService = courseService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CourseDTO>> GetAsync()
        {
            return await _courseService.GetAllAsync();
        }

        // GET api/<CourseController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetAsync(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<CourseController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CourseDTO course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _courseService.CreateAsync(course);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CourseDTO data)
        {
            var course = await _courseService.UpdateAsync(id, data);

            return course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CourseController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _courseService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
