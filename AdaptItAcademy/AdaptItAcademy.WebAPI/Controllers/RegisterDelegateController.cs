﻿using AdaptITAcademy.BusinessLogic.Business;
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
        //IRegisterDelegateService _registerDelegateRules;
        //private ICourseTrainingService<TrainingReadDTO> _trainingRules;

        //public RegisterDelegateController(IRegisterDelegateService registerDelegateRules, ICourseTrainingService<TrainingReadDTO> trainingRules)
        //{
        //    _registerDelegateRules = registerDelegateRules;
        //    _trainingRules = trainingRules;
        //}

        //[HttpPost]
        //public ActionResult<RegisterDelegateDTO> RegisterDelegate([FromBody] RegisterDelegateDTO value)
        //{
        //    TrainingReadDTO trainingExistence = VerifyRelatedTableExistent(value.TrainingId);
        //    if (trainingExistence == null) return NotFound("Training referenced for training not existing");

        //    _registerDelegateRules.RegisterDelegate(value);
        //    return Created("", "");
        //}

        //private TrainingReadDTO VerifyRelatedTableExistent(int id)
        //{
        //    int trainingCourseIdInput = id;
        //    TrainingReadDTO training = _trainingRules.GetById(trainingCourseIdInput);

        //    return training;
        //}
    }
}
