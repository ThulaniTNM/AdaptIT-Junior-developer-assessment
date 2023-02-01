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
        public void RegisterDelegate([FromBody] RegisterDelegateDTO value)
        {
            _registerDelegateRules.RegisterDelegate(value);
        }
    }
}
