using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseTrainingService<CourseReadDTO, CourseWriteDTO> _courseRepository;

        public CourseController(ICourseTrainingService<CourseReadDTO, CourseWriteDTO> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CourseReadDTO>> GetAllCourse()
        {
            List<CourseReadDTO> courses = _courseRepository.GetAll();

            if (courses.Count == 0) { return NotFound("Course list is empty"); };

            return Ok(courses);
        }

        [HttpGet("{id}", Name = "GetCourseById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CourseReadDTO> GetCourseById(int id)
        {
            if (id == 0) return BadRequest("Non existent course");

            var course = GetCourse(id);
            if (course == null) return NotFound("Course not found");

            return Ok(course);
        }

        [HttpPost]
        [Route("AddCourse")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CourseWriteDTO> Post([FromBody] CourseWriteDTO courseDTO)
        {
            if (courseDTO == null) return BadRequest("Non existent course");

          _courseRepository.Add(courseDTO);
            _courseRepository.SaveChanges();

            // last entry insert in db is what we just saved.
            CourseReadDTO courseRead = _courseRepository.GetAll().LastOrDefault();
            return CreatedAtRoute("GetCourseById", new { id = courseRead.CourseId }, courseDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<CourseReadDTO> Put(int id, [FromBody] CourseReadDTO courseDTO)
        {
            if (id == 0 || id != courseDTO.CourseId) return BadRequest($"Incorrect supplied id {id}");

            var course = GetCourse(id);
            if (course == null) return NotFound($"Course with ID {id} does not exist");

            _courseRepository.Update(id, courseDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<CourseReadDTO> Delete(int id)
        {
            if (id == 0) return BadRequest($"Incorrect supplied id {id}");

            var course = GetCourse(id);
            if (course == null) return NotFound($"Course with ID {id} does not exist");

            _courseRepository.Delete(id);
            return NoContent();
        }

        // Reusable helper methods declarations
        private CourseReadDTO GetCourse(int id)
        {
            return _courseRepository.GetById(id);
        }
    }
}
