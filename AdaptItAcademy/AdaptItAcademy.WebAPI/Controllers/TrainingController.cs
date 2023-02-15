using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using AdaptITAcademy.DataAccess.Repository;
using AdaptITAcademyAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/Training")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private ICourseTrainingService<TrainingReadDTO, TrainingWriteDTO> _trainingService;
        private ICourseTrainingService<CourseReadDTO, CourseWriteDTO> _courseService;

        public TrainingController(
            ICourseTrainingService<TrainingReadDTO, TrainingWriteDTO> trainingService,
            ICourseTrainingService<CourseReadDTO, CourseWriteDTO> courseService)
        {
            _trainingService = trainingService;
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TrainingReadDTO>> GetAllTrainings()
        {
            List<TrainingReadDTO> trainings = _trainingService.GetAll();

            if (trainings.Count == 0) { return NotFound("Training list is empty"); };

            return Ok(trainings);
        }

        [HttpGet("{id}", Name = "GetTrainingById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TrainingReadDTO> GetTrainingById(int id)
        {
            if (id == 0) return BadRequest("Non existent training");

            var training = GetTraining(id);
            if (training == null) return NotFound("Training not found");

            return Ok(training);
        }

        [HttpPost]
        [Route("AddTraining")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<TrainingReadDTO> Post([FromBody] TrainingWriteDTO trainingDTO)
        {
            if (trainingDTO == null) return BadRequest("Non existent training");

            CourseReadDTO trainingCourseExistence = VerifyRelatedTableExistent(trainingDTO.CourseId);
            if (trainingCourseExistence == null) return NotFound("Course referenced for training not existing");

           _trainingService.Add(trainingDTO);
            _trainingService.SaveChanges();
            // last entry insert in db is what we just saved.
            TrainingReadDTO trainingRead = _trainingService.GetAll().LastOrDefault();
            return CreatedAtRoute("GetTrainingById", new { id = trainingRead.TrainingID }, trainingDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TrainingReadDTO> Put(int id, [FromBody] TrainingReadDTO trainingDTO)
        {
            if (id == 0 || id != trainingDTO.TrainingID) return BadRequest($"Incorrect supplied id {id}");

            var training = GetTraining(id);
            if (training == null) return NotFound($"Training with ID {id} does not exist");

            CourseReadDTO trainingCourseExistence = VerifyRelatedTableExistent(trainingDTO.CourseId);
            if (trainingCourseExistence == null) return NotFound("Course referenced for training not existing");

            _trainingService.Update(id, trainingDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TrainingReadDTO> Delete(int id)
        {
            if (id == 0) return BadRequest($"Incorrect supplied id {id}");

            var training = GetTraining(id);
            if (training == null) return NotFound($"Training with ID {id} does not exist");

            _trainingService.Delete(id);
            return NoContent();
        }

        // Reusable helper methods declarations
        // make generic and static, rename to GetById
        private TrainingReadDTO GetTraining(int id)
        {
            return _trainingService.GetById(id);
        }


        // course to create training for has to exist first.
        // refactor to use one generic class.
        private CourseReadDTO VerifyRelatedTableExistent(int id)
        {
            int trainingCourseIdInput = id;
            CourseReadDTO course = _courseService .GetById(trainingCourseIdInput);
            return course;
        }
    }
}
