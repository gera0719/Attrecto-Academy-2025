using Academy2025.Data;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public static List<Course>? Courses = new List<Course>();
        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return Courses;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id)
                {
                    return Ok(course);
                }
            }
            return NotFound();
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Courses.Add(course);

            return Ok();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course course)
        {
            foreach (var c in Courses)
            {
                if (c.Id == id)
                {
                    course.Name = c.Name;
                    course.Description = c.Description;

                    return NoContent();
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id)
                {
                    Courses.Remove(course);

                    return NoContent();
                }
            }
            return NotFound();
        }
    }
}
