using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademyAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdaptItAcademyController : ControllerBase
    {
        private CourseRules _courseRules;

        public AdaptItAcademyController()
        {
            _courseRules = new CourseRules();
        }
        // GET: api/<AdaptItAcademyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdaptItAcademyController>/5
        [HttpGet("{id}")]
        public ActionResult<CourseDTO>  Get(int id)
        {
            var course =_courseRules.GetCourseById(id);

            return Ok(course);
        }

        // POST api/<AdaptItAcademyController>
        [HttpPost]
        [Route("AddCourse")]
        public ActionResult<CourseDTO> Post([FromBody] CourseDTO courseDTO)
        {
            _courseRules.AddCourse(courseDTO);
            return Ok(courseDTO);
        }

        // PUT api/<AdaptItAcademyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CourseDTO courseDTO)
        {
            _courseRules.UpdateCourse(id, courseDTO);

        }

        // DELETE api/<AdaptItAcademyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
