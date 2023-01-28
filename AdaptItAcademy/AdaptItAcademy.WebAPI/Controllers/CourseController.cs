using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseRules _courseRules;

        public CourseController() // inject dependency?
        {
            _courseRules = new CourseRules();
        }

        [HttpGet]
        public ActionResult<List<CourseDTO>> GetAllCourse()
        {
            List<CourseDTO> courses = _courseRules.GetAllCourses();
            
            if(courses.Count == 0) { return NotFound("Course list is empty"); };

            return courses;
        }

        [HttpGet("{id}", Name = "GetCourseById")]
        public ActionResult<CourseDTO> GetCourseById(int id)
        {
            if (id == 0) return BadRequest("Non existent course");

            var course = GetCourse(id);
            if (course == null) return NotFound("Course not found");

            return Ok(course);
        }

        [HttpPost]
        [Route("AddCourse")]
        public ActionResult<CourseDTO> Post([FromBody] CourseDTO courseDTO)
        {
            if (courseDTO == null) return BadRequest("Non existent course");

            var courseID = courseDTO.CourseId;
            bool isCourseExisting = GetCourse(courseID) == null ? false : true;

            if (isCourseExisting) return BadRequest($"Course with ID {courseID} already exists");

            _courseRules.AddCourse(courseDTO);
            return CreatedAtRoute("GetCourseById", courseDTO);
        }

        [HttpPut("{id}")]
        public ActionResult<CourseDTO> Put(int id, [FromBody] CourseDTO courseDTO)
        {
            if (id == 0 || id != courseDTO.CourseId) return BadRequest($"Incorrect supplied id {id}");
            
            var course = GetCourse(id);
            if (course == null) return NotFound($"Course with ID {id} does not exist");

            _courseRules.UpdateCourse(id, courseDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<CourseDTO>  Delete(int id)
        {
            if (id == 0 ) return BadRequest($"Incorrect supplied id {id}");

            var course = GetCourse(id);
            if (course == null) return NotFound($"Course with ID {id} does not exist");

            _courseRules.DeleteCourse(id);
            return NoContent();
        }

        public CourseDTO GetCourse(int id)
        {
            return _courseRules.GetCourseById(id);
        }
    }
}
