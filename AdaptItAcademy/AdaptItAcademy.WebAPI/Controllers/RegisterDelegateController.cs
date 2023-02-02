using AdaptITAcademy.BusinessLogic.Business;
using AdaptITAcademy.BusinessLogic.Business_Rules;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptItAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDelegateController : ControllerBase
    {
        IRegisterDelegateRules _registerDelegateRules;
        public RegisterDelegateController(IRegisterDelegateRules registerDelegateRules)
        {
            _registerDelegateRules = registerDelegateRules;

        }

        [HttpPost]
        public ActionResult<RegisterDelegateDTO> RegisterDelegate([FromBody] RegisterDelegateDTO value)
        {
            TrainingDTO trainingExistence = VerifyRelatedTableExistent(value.TrainingId);
            if (trainingExistence == null) return NotFound("Training referenced for training not existing");

            _registerDelegateRules.RegisterDelegate(value);
            return Created("", "");
        }

        private TrainingDTO VerifyRelatedTableExistent(int id)
        {
            int trainingCourseIdInput = id;
            IRules<TrainingDTO> trainingRules = new TrainingRules();
            TrainingDTO training = trainingRules.GetById(trainingCourseIdInput);

            return training;
        }
    }
}
