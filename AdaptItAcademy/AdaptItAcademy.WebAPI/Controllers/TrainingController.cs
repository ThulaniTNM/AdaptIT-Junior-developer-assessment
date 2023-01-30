using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/Training")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private TrainingRules _trainingRules;

        public TrainingController()
        {
            _trainingRules = new TrainingRules();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TrainingDTO>> GetAllTrainings()
        {
            List<TrainingDTO> trainings = _trainingRules.GetAllTrainings();

            if (trainings.Count == 0) { return NotFound("Training list is empty"); };

            return Ok(trainings);
        }

        [HttpGet("{id}", Name = "GetTrainingById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TrainingDTO> GetTrainingById(int id)
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
        public ActionResult<TrainingDTO> Post([FromBody] TrainingDTO trainingDTO)
        {
            if (trainingDTO == null) return BadRequest("Non existent training");

            var trainingID = trainingDTO.CourseId;
            bool isTrainingExisting = GetTraining(trainingID) == null ? false : true;

            if (isTrainingExisting) return BadRequest($"Training with ID {trainingID} already exists"); // valid data may require internal server error.

            _trainingRules.AddTraining(trainingDTO);
            return CreatedAtRoute("GetTrainingById", new { id = trainingDTO.TrainingID }, trainingDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TrainingDTO> Put(int id, [FromBody] TrainingDTO trainingDTO)
        {
            if (id == 0 || id != trainingDTO.TrainingID) return BadRequest($"Incorrect supplied id {id}");

            var training = GetTraining(id);
            if (training == null) return NotFound($"Training with ID {id} does not exist");

            _trainingRules.UpdateTraining(id, trainingDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TrainingDTO> Delete(int id)
        {
            if (id == 0) return BadRequest($"Incorrect supplied id {id}");

            var training = GetTraining(id);
            if (training == null) return NotFound($"Training with ID {id} does not exist");

            _trainingRules.DeleteTraining(id);
            return NoContent();
        }

        // Reusable helper methods declarations
        // make generic and static, rename to GetById
        private TrainingDTO GetTraining(int id)
        {
            return _trainingRules.GetCourseById(id);
        }
    }
}
