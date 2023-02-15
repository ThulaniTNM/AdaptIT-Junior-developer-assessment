using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using AdaptITAcademy.DataAccess.Repository.@interface;
using AdaptITAcademyAPI.Models;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Training;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDelegateController : ControllerBase
    {
        private IRegisterDelegateService _registerDelegateService;
        private ICourseTrainingService<TrainingReadDTO,TrainingWriteDTO> _trainingRepository;

        public RegisterDelegateController(IRegisterDelegateService registerDelegateService, ICourseTrainingService<TrainingReadDTO,TrainingWriteDTO> trainingRepository)
        {
            _registerDelegateService = registerDelegateService;
            _trainingRepository = trainingRepository;
        }

        [HttpPost]
        public ActionResult<RegisterDelegateDTO> RegisterDelegate([FromBody] RegisterDelegateDTO value)
        {
            if (value.TrainingId == 0) return BadRequest("Incorrect training id");
            TrainingReadDTO trainingExistence = VerifyRelatedTableExistent(value.TrainingId);
            if (trainingExistence == null) return NotFound("Training referenced for training not existing");

            using (IDbContextTransaction transaction = _registerDelegateService.GetContext().Database.BeginTransaction())
            {
                try
                {
                    _registerDelegateService.RegisterDelegate(value);

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500,ex.Message);
                }
            }
            var registered = new { status = "Delegate registered for training", value };
            return Ok(registered);
        }

        private TrainingReadDTO VerifyRelatedTableExistent(int id)
        {
            int trainingCourseIdInput = id;
            TrainingReadDTO training = _trainingRepository.GetById(trainingCourseIdInput);

            return training;
        }
    }
}
