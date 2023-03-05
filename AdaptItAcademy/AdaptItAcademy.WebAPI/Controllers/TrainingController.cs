using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/Training")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private ICourseTrainingService<TrainingReadDTO, TrainingWriteDTO> _trainingService;

        public TrainingController(
            ICourseTrainingService<TrainingReadDTO, TrainingWriteDTO> trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TrainingReadDTO>> GetAllTrainings()
        {
            List<TrainingReadDTO> trainings = _trainingService.GetAll();
            return Ok(trainings);
        }

        [HttpGet("{id}", Name = "GetTrainingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TrainingReadDTO> GetTrainingById(int id)
        {
            var training = _trainingService.GetById(id);
            return Ok(training);
        }

        [HttpPost]
        [Route("AddTraining")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TrainingReadDTO> Post([FromBody] TrainingWriteDTO trainingDTO)
        {
            _trainingService.Add(trainingDTO);

            // last entry insert in db is what we just saved.
            TrainingReadDTO trainingRead = _trainingService.GetAll().LastOrDefault();
            return CreatedAtRoute("GetTrainingById", new { id = trainingRead.TrainingID }, trainingDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TrainingReadDTO> Put(int id, [FromBody] TrainingWriteDTO trainingDTO)
        {
            _trainingService.Update(id, trainingDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TrainingReadDTO> Delete(int id)
        {
            _trainingService.Delete(id);
            return NoContent();
        }
    }
}
